namespace CR.Panenado.API.Models
{
    public class TipoProductoModel
    {
        public int IdTipoProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public bool Activo { get; set; }
    }
}
