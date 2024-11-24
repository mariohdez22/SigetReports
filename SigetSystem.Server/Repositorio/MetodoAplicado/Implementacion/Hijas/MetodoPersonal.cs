using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Hubs;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoPersonal : IMetodoPersonal
    {
        private readonly IMetodoGenerico<Personal> _repositorio;
        private readonly IHubContext<HubRegistro> _hubRegistro;

        public MetodoPersonal(IMetodoGenerico<Personal> repositorio,
                              IHubContext<HubRegistro> hubRegistro)
        {
            _repositorio = repositorio;
            _hubRegistro = hubRegistro;
        }

        public IQueryable<Personal> OrdenarPersonal(IQueryable<Personal> lista, Expression<Func<Personal, int>> criterioOrden, string FormatoOrden)
        {
            var resultado = FormatoOrden == "Ascendente"
                                         ? lista.OrderBy(criterioOrden)
                                         : FormatoOrden == "Descendente"
                                                        ? lista.OrderByDescending(criterioOrden)
                                                        : null;
            if (resultado == null)
                return lista;
            else
                return resultado;
        }

        public async Task<(List<Personal>, int totalRegistros)> ConsultaPersonal(ParametrosPaginacion pp)
        {
            IQueryable<Personal> lista = await _repositorio.Consulta();

            if (pp.ID1 != 0)
            {
                lista = lista.Where(p => p.IdRangoPersonal == pp.ID1);
            }

            if (pp.ID2 != 0)
            {
                lista = lista.Where(p => p.IdEstadoPersonal == pp.ID2);
            }

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(
                    b => b.Nombres!.Contains(pp.Buscar) ||
                         b.Celular!.Contains(pp.Buscar) ||
                         b.Email!.Contains(pp.Buscar)   ||
                         b.DUI!.Contains(pp.Buscar)     ||
                         b.Nickname!.Contains(pp.Buscar));
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarPersonal(lista, p => p.IdPersonal, pp.Orden);

            var listaPersonal = await listaOrdenada
                                            .Include(t => t.RangoPersonal)
                                            .Include(e => e.EstadoPersonal)
                                            .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                                            .Take(pp.TamañoPagina)
                                            .ToListAsync();

            return (listaPersonal, totalRegistros);
        }

        public async Task<Personal> BuscarPersonal(int ID)
        {
            return await _repositorio.Buscar(ID);
        }

        public async Task<Personal> CrearPersonal(Personal entidad)
        {
            try
            {
                entidad.Contrasena = HashPassword(entidad.Contrasena);

                Personal personal = await _repositorio.Crear(entidad);

                await _hubRegistro.Clients.All.SendAsync("ObtencionMensaje", "El registro se creo correctamente.");

                return personal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Personal> EditarPersonal(Personal entidad)
        {
            try
            {
                Personal articulo = await _repositorio.Editar(entidad);

                await _hubRegistro.Clients.All.SendAsync("RegistroEditado", "El registro se edito correctamente.");

                return articulo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task BorrarPersonal(Personal entidad)
        {
            try
            {
                await _repositorio.Borrar(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------------------------

        public async Task<List<Personal>> ConsultaPersonalSimple()
        {
            IQueryable<Personal> lista = await _repositorio.Consulta();

            var listaPersonal = await lista.Include(t => t.RangoPersonal)
                                           .Include(e => e.EstadoPersonal)
                                           .ToListAsync();

            return listaPersonal;
        }

        //---------------------------------------------------------------------------------------------------

        private string HashPassword(string plainPassword)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var rfcPassord = new Rfc2898DeriveBytes(plainPassword, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassord.GetBytes(20);

            byte[] passwordHash = new byte[36];
            Array.Copy(salt, 0, passwordHash, 0, 16);
            Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);

            return Convert.ToBase64String(passwordHash);
        }

    }
}
