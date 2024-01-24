using Hangfire;
using Microsoft.IdentityModel.Tokens;
using SigetSystem.Server.Models.Entidades.Independientes;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Independientes;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Independientes
{
    public class MetodoJobReporte : IMetodoJobReporte
    {
        private readonly IMetodoGenerico<JobReporte> _repoGenerico;
        private readonly IBackgroundJobClient _bjob;

        public MetodoJobReporte(IMetodoGenerico<JobReporte> repoGenerico, IBackgroundJobClient bjob)
        {
            _repoGenerico = repoGenerico;
            _bjob = bjob;
        }

        public async Task<JobReporte> CrearJobReporte(JobReporte jobReporte)
        {
            try
            {
                return await _repoGenerico.Crear(jobReporte);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<JobReporte> GuardarJobReporte(int id, string token)
        {
            try
            {
                JobReporte job = new JobReporte()
                {
                    IdJob = id,
                    TokenJob = token
                };

                return await CrearJobReporte(job);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<JobReporte> BuscarJobReporte(int id)
        {
            return await _repoGenerico.BuscarJob(id, "IdReporteInspeccion");
        }

        public bool BorrarJobReporte(string token)
        {
            return _bjob.Delete(token);
        }
    }
}
