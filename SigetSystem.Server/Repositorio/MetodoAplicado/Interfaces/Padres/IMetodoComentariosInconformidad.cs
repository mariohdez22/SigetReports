﻿namespace SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres
{
    public interface IMetodoComentariosInconformidad
    {
        Task<List<ComentariosInconformidad>> ConsultaComentariosInconformidad();
    }
}
