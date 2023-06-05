using CR.Panenado.BE;
using CR.Panenado.DA;
using CR.Panenado.EF.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CR.Paneando.BL
{
    public class ProductoBL
    {
        private readonly ProductoDA objProductoDA;

        public ProductoBL()
        {
            objProductoDA= new ProductoDA();
        }

        public IEnumerable<ProductoCatalogoBE> ListarCatalogo(string texto) {
            try
            {

                IEnumerable<ProductoCatalogoBE> lstProductos;
                if (texto.IsNullOrEmpty())
                    lstProductos = objProductoDA.ListarCatalogo();
                else {
                    lstProductos = objProductoDA.FiltrarCatalogoPorNombreODescripcion(texto);
                }

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

        public IEnumerable<ProductoCatalogoBE> ListarProductosPorListaIds(String strProductos)
        {
            try
            {
                var lstIdProductos = strProductos.Split(',').Select(int.Parse).ToList();
                if (lstIdProductos.IsNullOrEmpty())
                    throw new Exception("La lista no contiene Ids");
                else {
                    return objProductoDA.ListarProductosPorListaIds(lstIdProductos);
                }
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
    }
}