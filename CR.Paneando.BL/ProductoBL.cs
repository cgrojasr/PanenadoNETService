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
    }
}