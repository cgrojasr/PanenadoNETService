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

        public IEnumerable<ProductoBE.Catalogo> ListarCatalogo(string texto) {
            try
            {

                IEnumerable<ProductoBE.Catalogo> lstProductos;
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
    }
}