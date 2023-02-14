using CR.Panenado.EF.Entities;

namespace CR.Panenado.DA
{
    public class ProductoDA
    {
        private readonly DbPaneandoContext dc;

        public ProductoDA()
        {
            dc = new DbPaneandoContext();
        }

        public IQueryable<Producto> Listar_Disponibles() {
            var query = dc.Productos.Where(x => x.Activo && x.IdTipoProducto.Equals(1))
                .OrderBy(x=>x.Nombre);

            return query;
        }
    }
}