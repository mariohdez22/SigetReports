using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SigetSystem.Server.Models.Contexto;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Independientes;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.DTOs.Independientes;
using SigetSystem.Shared.MPPs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Independientes
{
    public class MetodoLogin : IMetodoLogin
    {

        private readonly IMetodoGenerico<Personal> _repositorio;
        private readonly TokenSettings _tokenSettings;

        public MetodoLogin(IMetodoGenerico<Personal> repositorio, IOptions<TokenSettings> tokenSettings)
        {
            _repositorio = repositorio;
            _tokenSettings = tokenSettings.Value;
        }

        private bool VerifyPasswordHash(string DtoContrasena, string dbContrasena)
        {
            byte[] dbPasswordHash = Convert.FromBase64String(dbContrasena);

            byte[] salt = new byte[16];
            Array.Copy(dbPasswordHash, 0, salt, 0, 16);

            var rfcPassord = new Rfc2898DeriveBytes(DtoContrasena, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassord.GetBytes(20);

            for (int i = 0; i < rfcPasswordHash.Length; i++)
            {
                if (dbPasswordHash[i + 16] != rfcPasswordHash[i])
                {
                    return false;
                }
            }
            return true;
        }

        private string GenerateToken(Personal personal)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("Sub", personal.IdPersonal.ToString()),
                new Claim("Nickname", personal.Nickname),
                new Claim("Nombre", personal.Nombres),
                new Claim("Celular", personal.Celular),
                new Claim("Email", personal.Email),
                new Claim("DUI", personal.DUI),
                new Claim("FechaNacimiento", personal.FechaNacimiento.ToString()),
                new Claim("Estado", personal.EstadoPersonal.Estados),
                new Claim("Rango", personal.RangoPersonal.Rangos)
            };

            var securityToken = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public async Task<(bool IsSuccess, string Token)> LoginPersonal(LoginDTO loginDto)
        {
            try
            {
                if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Contrasena))
                {
                    return (false, "");
                }

                Personal personal = await _repositorio.BuscarPorCondicion(
                                                       p => p.Email == loginDto.Email, 
                                                       p => p.RangoPersonal,           
                                                       p => p.EstadoPersonal);

                if (personal == null)
                {
                    return (false, "");
                }

                if (!VerifyPasswordHash(loginDto.Contrasena, personal.Contrasena))
                {
                    return (false, "");
                }

                var jwtAccessToken = GenerateToken(personal);

                return (true, jwtAccessToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

