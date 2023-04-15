using CR.Panenado.EF.Entities;
using System.Text.Json.Serialization;

namespace CR.Panenado.API.Models
{
    public class ProductoModel
    {
        [JsonPropertyName("id_producto")]
        public int IdProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        [JsonPropertyName("id_tipo_producto")]
        public int IdTipoProducto { get; set; }

        public bool Activo { get; set; } = true;
    }

    //public class CatalogoDisponible
    //{
    //    [JsonPropertyName("id_producto")]
    //    public int IdProducto { get; set; }

    //    public string Nombre { get; set; } = null!;

    //    public string Descripcion { get; set; } = null!;

    //    [JsonPropertyName("tipo_producto")]
    //    public string TipoProducto { get; set; } = null!;

    //    [JsonPropertyName("valor_venta")]
    //    public double ValorVenta { get; set; }

    //    public bool Activo { get; set; }
    //}
}
