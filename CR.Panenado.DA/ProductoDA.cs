using CR.Panenado.BE;
using CR.Panenado.EF.Entities;
using System.Net.Mime;

namespace CR.Panenado.DA
{
    public class ProductoDA
    {
        private readonly DbPaneandoContext dc;

        public ProductoDA()
        {
            dc = new DbPaneandoContext();
        }

        public IEnumerable<ProductoBE.Catalogo> ListarCatalogo() {
            var productos = from pro in dc.Productos.Where(x => x.Activo && x.IdTipoProducto.Equals(1))
                            join pre in dc.ProductoPrecios.Where(x=>x.Activo) on pro.IdProducto equals pre.IdProducto
                            join tip in dc.TipoProductos on pro.IdTipoProducto equals tip.IdTipoProducto
                            orderby pro.IdTipoProducto
                            select new ProductoBE.Catalogo
                            {
                                IdProducto = pro.IdProducto,
                                Nombre = pro.Nombre,
                                Descripcion = pro.Descripcion,
                                TipoProducto = tip.Nombre,
                                ValorVenta = pre.ValorVenta
                            };
            return productos;
        }

        public ProductoBE.Catalogo BuscarCatalogoPorIdProducto(int idProducto) { 
            var producto = from pro in dc.Productos.Where(x=>x.IdProducto.Equals(idProducto))
                           join pre in dc.ProductoPrecios on pro.IdProducto equals pre.IdProducto
                           join tip in dc.TipoProductos on pro.IdTipoProducto equals tip.IdTipoProducto
                           orderby pro.IdTipoProducto
                           select new ProductoBE.Catalogo
                           {
                               IdProducto = pro.IdProducto,
                               Nombre = pro.Nombre,
                               Descripcion = pro.Descripcion,
                               TipoProducto = tip.Nombre,
                               ValorVenta = pre.ValorVenta
                           };

            return producto.Single();
        }

        public IEnumerable<ProductoBE.Precio> BuscarPrecioPorListaIdProductos(List<int> lstIdProductos) {
            var lstProductosPrecio = from pre in dc.ProductoPrecios.Where(x => lstIdProductos.All(i => i.Equals(x.IdProducto)) && x.Activo)
                                     orderby pre.IdProducto
                                     select new ProductoBE.Precio
                                     {
                                         IdProducto = pre.IdProducto,
                                         ValorVenta = pre.ValorVenta
                                     };

            return lstProductosPrecio;
        }

        public int Registrar(Producto objProducto)
        {
            dc.Productos.Add(objProducto);
            dc.SaveChanges();
            return objProducto.IdProducto;
        }
    }
}