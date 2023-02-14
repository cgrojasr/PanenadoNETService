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

        public IQueryable<Producto> Listar_Disponibles() {
            try
            {
                return objProductoDA.Listar_Disponibles();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}