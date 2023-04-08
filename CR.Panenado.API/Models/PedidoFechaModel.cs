using System.Text.Json.Serialization;

namespace CR.Panenado.API.Models
{
    public class PedidoFechaModel
    {
        public class Entidad {
            [JsonPropertyName("id_pedido_fecha")]
            public int IdPedidoFecha { get; set; }

            [JsonPropertyName("id_pedido")]
            public int IdPedido { get; set; }

            [JsonPropertyName("dia_semana")]
            public string? DiaSemana { get; set; }

            public DateTime? Fecha { get; set; }

            [JsonPropertyName("hora_minuto")]
            public TimeSpan? HoraMinuto { get; set; }

            public bool Activo { get; set; }
        }
    }
}
