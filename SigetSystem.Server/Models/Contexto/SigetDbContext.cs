using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Models.Entidades.Independientes;
using SigetSystem.Server.Models.Entidades.Padres;

namespace SigetSystem.Server.Models.Contexto
{
    public class SigetDbContext : DbContext
    {
        public SigetDbContext(DbContextOptions<SigetDbContext> options) : base(options)
        {
                
        }

        public DbSet<Personal> Personals { get; set; }

        public DbSet<Organismo> Organismos { get; set; }

        public DbSet<RequisitoMenor> RequisitoMenors { get; set; }

        public DbSet<RequisitoMayor> RequisitoMayors  { get; set; }

        public DbSet<ComentarioSiget> ComentarioSigets  { get; set; }

        public DbSet<Representante> Representantes { get; set; }

        public DbSet<ReporteInspeccion> ReporteInspeccions { get; set; }

        public DbSet<Bitacora> Bitacoras { get; set; }

        public DbSet<RangoPersonal> RangoPersonals { get; set; }

        public DbSet<EstadoAcreditacion> EstadoAcreditacions { get; set; }

        public DbSet<EstadoPersonal> EstadoPersonals { get; set; }

        public DbSet<TipoConformidad> TipoConformidads { get; set; }

        public DbSet<EstadoComentario> EstadoComentarios { get; set; }

        public DbSet<EstadoRepresentante> EstadoRepresentantes { get; set; }

        public DbSet<CodigoSiget> CodigoSigets { get; set; }

        public DbSet<CodigoConformidad> CodigoConformidads { get; set; }

        public DbSet<MunicipioInstalacion> MunicipioInstalacions { get; set; }

        public DbSet<ComentariosInconformidad> ComentariosInconformidads { get; set; }

        public DbSet<EstadoReporte> EstadoReportes { get; set; }

        public DbSet<DepartamentoInstalacion> DepartamentoInstalacions { get; set; }
    }
}
