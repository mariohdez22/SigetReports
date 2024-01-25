using AutoMapper;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Models.Entidades.Padres;
using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.DTOs.Padres;

namespace SigetSystem.Server
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ComentarioSiget, ComentarioSigetDTO>().ReverseMap();
            CreateMap<Organismo, OrganismoDTO>().ReverseMap();
            CreateMap<Personal, PersonalDTO>().ReverseMap();
            CreateMap<ReporteInspeccion, ReporteInspeccionDTO>().ReverseMap();
            CreateMap<Representante, RepresentanteDTO>().ReverseMap();
            CreateMap<RequisitoMayor, RequisitoMayorDTO>().ReverseMap();
            CreateMap<RequisitoMenor, RequisitoMenorDTO>().ReverseMap();

            CreateMap<CodigoConformidad, CodigoConformidadDTO>().ReverseMap();
            CreateMap<CodigoSiget, CodigoSigetDTO>().ReverseMap();
            CreateMap<ComentariosInconformidad, ComentariosInconformidadDTO>().ReverseMap();
            CreateMap<DepartamentoInstalacion, DepartamentoInstalacionDTO>().ReverseMap();
            CreateMap<EstadoAcreditacion, EstadoAcreditacionDTO>().ReverseMap();
            CreateMap<EstadoComentario, EstadoComentarioDTO>().ReverseMap();
            CreateMap<EstadoPersonal, EstadoPersonalDTO>().ReverseMap();
            CreateMap<EstadoReporte, EstadoReporteDTO>().ReverseMap();
            CreateMap<EstadoRepresentante, EstadoRepresentanteDTO>().ReverseMap();
            CreateMap<MunicipioInstalacion, MunicipioInstalacionDTO>().ReverseMap();
            CreateMap<RangoPersonal, RangoPersonalDTO>().ReverseMap();
            CreateMap<TipoConformidad, TipoConformidadDTO>().ReverseMap();
        }
    }
}
