using CR.Panenado.BE;
using CR.Panenado.DA;
using CR.Panenado.EF.Entities;

namespace CR.Paneando.BL
{
    public class ProductoBL
    {
        private readonly ProductoDA objProductoDA;

        public ProductoBL()
        {
            objProductoDA= new ProductoDA();
        }

        public IEnumerable<ProductoBE.Catalogo> ListarCatalogo() {
            try
            {
                var lstProductos = objProductoDA.ListarCatalogo();
                if (lstProductos.Count().Equals(0))
                    throw new Exception("La consulta no contiene elementos");

                return lstProductos;
                    
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Producto Registrar(Producto objProducto) {
            try
            {
                objProducto.IdProducto = objProductoDA.Registrar(objProducto);
                return objProducto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Producto Actualizar(Producto objProducto) {
            try
            {
                return objProductoDA.Actualizar(objProducto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Producto Eliminar(int idProducto) {
            try
            {
                var objProducto = objProductoDA.BuscarPorId(idProducto);
                if (objProducto != null)
                    return objProductoDA.Eliminar(objProducto);
                else
                    throw new Exception("No se encontro el producto a eliminar");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ProductoBE.Catalogo> BuscarPorListaIdProductos(string strIdProductos)
        {
            try {
                var lstIdProductos = Array.ConvertAll(strIdProductos.Split(','), int.Parse);
                var productos = objProductoDA.BuscarPorListaIdProductos(lstIdProductos.ToList());
                if (productos.Count() > 0)
                    return productos;
                else throw new Exception("No se encontraron resultados");
            }
            catch (Exception) { 
                throw;
            }

        }
    }
}