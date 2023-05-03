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

        public IEnumerable<ProductoCatalogoBE> BuscarPorListaIdProductos(String strProductos)
        {
            try
            {
                var lstIdProductos = strProductos.Split(',').Select(int.Parse).ToList();
                if (lstIdProductos.IsNullOrEmpty())
                    throw new Exception("La lista no contiene Ids");
                else {
                    return objProductoDA.BuscarPorListaIdProductos(lstIdProductos);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}