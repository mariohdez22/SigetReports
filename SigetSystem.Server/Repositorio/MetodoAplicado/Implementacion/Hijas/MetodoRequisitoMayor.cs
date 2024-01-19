using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;

namespace SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas
{
    public class MetodoRequisitoMayor : IMetodoRequisitoMayor
    {
        private readonly IMetodoGenerico<RequisitoMayor> _repoGenerico;

        public MetodoRequisitoMayor(IMetodoGenerico<RequisitoMayor> repoGenerico)
        {
            _repoGenerico = repoGenerico;
        }

        public IQueryable<RequisitoMayor> OrdenarRequisitos
        (
            IQueryable<RequisitoMayor> lista,
            Expression<Func<RequisitoMayor, int>> criterioOrdern,
            string formatoOrden
        )
        {
            var resultado = formatoOrden == "Ascendente"
                ? lista.OrderBy(criterioOrdern)
                : formatoOrden == "Descendente"
                    ? lista.OrderByDescending(criterioOrdern)
                    : null;

            if (resultado == null)
            {
                return lista;
            }
            else
            {
                return resultado;
            }
        }

        public async Task<(List<RequisitoMayor>, int totalRegistros)> ConsultaRquisitoMayor(ParametrosPaginacion pp)
        {
            IQueryable<RequisitoMayor> lista = await _repoGenerico.Consulta();

            if (pp.ID1 != 0)
            {
                lista = lista.Where(p => p.IdOrganismo == pp.ID1);
            }

            if (pp.ID2 != 0)
            {
                lista = lista.Where(pp => p.IdRepresentante == pp.ID2);
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarRequisitos(lista, p => p.IdMayores, pp.Orden);

            var listaRequisitos = await 
                listaOrdenada
                    .Include(o => o.IdOrganismo)
                    .Include(r => r.IdRepresentante)
                    .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                    .Take(pp.NumeroPagina)
                    .ToListAsync();

            return (listaRequisitos, totalRegistros);
        }

        public async Task<RequisitoMayor> BuscarRequisitoMayor(int id)
        {
            return await _repoGenerico.Buscar(id);
        }

        public async Task<RequisitoMayor> CrearRequisitoMayor(RequisitoMayor requisitoMayor)
        {
            try
            {
                return await _repoGenerico.Crear(requisitoMayor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<RequisitoMayor> EditarRequisitoMayor(RequisitoMayor requisitoMayor)
        {
            try
            {
                return await _repoGenerico.Editar(requisitoMayor);
            }
            catch (Exception ex)
            {
                throw
            }
        }

        public async Task BorrarRequisitoMayor(RequisitoMayor requisitoMayor)
        {
            try
            {
                await _repoGenerico.Borrar(requisitoMayor);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
