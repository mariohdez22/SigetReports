using Microsoft.EntityFrameworkCore;
using SigetSystem.Server.Models.Entidades.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;
using SigetSystem.Shared.MPPs;
using System.Linq.Expressions;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoRequisitoMenor : IMetodoRequisitoMenor
    {
        private readonly IMetodoGenerico<RequisitoMenor> _repositorio;

        public MetodoRequisitoMenor(IMetodoGenerico<RequisitoMenor> repositorio)
        {
            _repositorio = repositorio;
        }

        public IQueryable<RequisitoMenor> OrdenarRequisitosMenores(IQueryable<RequisitoMenor> lista, Expression<Func<RequisitoMenor, int>> criterioOrden, string FormatoOrden)
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


        public async Task<(List<RequisitoMenor>, int totalRegistros)> ConsultarRequisitoMenor(ParametrosPaginacion pp)
        {
            IQueryable<RequisitoMenor> lista = await _repositorio.Consulta();

            if (pp.ID1 != 0)
            {
                lista = lista.Where(p => p.IdRepresentante == pp.ID1);
            }

            if (pp.ID2 != 0)
            {
                lista = lista.Where(p => p.IdOrganismo == pp.ID2);
            }

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(
                    z => z.CodigoRequisito!.Contains(pp.Buscar) ||
                         z.ArchivoCopiaDuiPropietario!.Contains(pp.Buscar) ||
                         z.ArchivoCopiaDuiRetiro!.Contains(pp.Buscar) ||
                         z.ArchivoCopiaDuiElectricista!.Contains(pp.Buscar) ||
                         z.ArchivoCopiaCarnetElectricista!.Contains(pp.Buscar)||
                         z.FechaRegistro!.ToString() == pp.Buscar);
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarRequisitosMenores(lista, p => p.IdMenores, pp.Orden);

            var listaPersonal = await listaOrdenada
                                            .Include(x => x.Representante)
                                            .Include(e => e.Organismo)
                                            .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                                            .Take(pp.TamañoPagina)
                                            .ToListAsync();

            return (listaPersonal, totalRegistros);
        }

        public async Task<RequisitoMenor> BuscarRequisitoMenor(int ID)
        {
            return await _repositorio.Buscar(ID);
        }

        public async Task<RequisitoMenor> CrearRequisitoMenor(RequisitoMenor requisitoMenor)
        {
            try
            {
                RequisitoMenor requisitoMenores = await _repositorio.Crear(requisitoMenor);

                return requisitoMenores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RequisitoMenor> EditarRequisitoMenor(RequisitoMenor requisitoMenor)
        {
            RequisitoMenor requisitoMenores = await _repositorio.Editar(requisitoMenor);

            return requisitoMenores;
        }

        public async Task BorrarRequisitoMenor(RequisitoMenor requisitoMenor)
        {
            try
            {
                await _repositorio.Borrar(requisitoMenor); 
            }
            catch (Exception)
            {

                throw;
            }
        }
    

       
    }
}
