using System.Text.Json.Serialization;

namespace CR.Panenado.API.Models
{
    public class PedidoDetalleModel
    {
        public class Entidad {
            [JsonPropertyName("id_pedido")]
            public int IdPedido { get; set; }

            [JsonPropertyName("id_producto")]
            public int IdProducto { get; set; }

            public int Cantidad { get; set; }

            [JsonPropertyName("valor_venta")]
            public double ValorVenta { get; set; }

            public bool Eliminado { get; set; }
        }
    }
}
