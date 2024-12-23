﻿using SigetSystem.Shared.DTOs.Hijas;
using SigetSystem.Shared.MPPs;

namespace SigetSystem.Client.Services.Interfaces
{
    public interface IRepresentanteService 
    {
        Task<APIResponse<List<RepresentanteDTO>>> MostrarRepresentante(ParametrosPaginacion pp);

        Task<List<RepresentanteDTO>> MostrarRepresentante();

        Task<RepresentanteDTO> BuscarRepresentante(int id);

        Task<string> CrearRepresentante(RepresentanteDTO representante);

        Task<string> EditarRepresentante(RepresentanteDTO representante, int id);

        Task<string> EliminarRepresentante(int id);

        //----------------------------------------------------------------------------------------

        Task<List<RepresentanteDTO>> MostrarRepresentanteSimple();
    }
}
