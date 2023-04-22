using System.Text.Json.Serialization;

namespace CR.Panenado.BE
{
    public class ProductoBE
    {
        public class Catalogo {
            [JsonPropertyName("id_producto")]
            public int IdProducto { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Descripcion { get; set; } = string.Empty;
            [JsonPropertyName("tipo_producto")]
            public string TipoProducto { get; set; } = string.Empty;
            [JsonPropertyName("valor_venta")]
            public double ValorVenta { get; set; }
            [JsonPropertyName("image_url")]
            public string? ImageUrl { get; set; }
        }

        public class Precio
        {
            [JsonPropertyName("id_producto")]
            public int IdProducto { get; set; }
            [JsonPropertyName("valor_venta")]
            public double ValorVenta { get; set; }
        }
    }
}