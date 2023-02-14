namespace CR.Panenado.API.Models
{
    public class PedidoModel
    {
        public class Entidad {
            public int id_pedido { get; set; }

            public DateTime fecha { get; set; }

            public string direccion { get; set; } = null!;

            public string email { get; set; } = null!;

            public int estado { get; set; }

            public DateTime? fecha_inicio { get; set; }

            public DateTime? fecha_fin { get; set; }

            public IQueryable<PedidoDetalleModel> items { get; set; }

        }

    }
}
