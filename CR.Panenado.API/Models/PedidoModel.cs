using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CR.Panenado.API.Models
{
    public class PedidoModel
    {
        public class Entidad {
            [JsonPropertyName("id_pedido")]
            public int IdPedido { get; set; }

            public DateTime Fecha { get; set; }

            public string Direccion { get; set; } = null!;

            public string Email { get; set; } = null!;

            public int Estado { get; set; }

            [JsonPropertyName("fecha_inicio")]
            public DateTime? FechaInicio { get; set; }

            [JsonPropertyName("fecha_fin")]
            public DateTime? FechaFin { get; set; }

            [JsonPropertyName("hora_minuto")]
            public TimeSpan? HoraMinuto { get; set; }

            public List<PedidoDetalleModel.Entidad>? Items { get; set; }

            public List<PedidoFechaModel.Entidad>? Fechas { get; set; }

        }

    }
}
