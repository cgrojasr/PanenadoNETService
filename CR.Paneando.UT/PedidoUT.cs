using CR.Paneando.BL;
using CR.Panenado.DA;
using CR.Panenado.EF.Entities;

namespace CR.Paneando.UT
{
    [TestClass]
    public class PedidoUT
    {
        [TestMethod]
        public void Registrar()
        {
            var pedido = new Pedido() {
                Direccion = "",
                Email = "",
                FechaInicio = new DateTime(2023, 4, 7),
                FechaFin = new DateTime(2023, 4, 10),
                Fecha = new DateTime(2023, 4, 7),
                HoraMinuto = new TimeSpan(8,0,0),
                Estado = 1
                //PedidoDetalles = new List<PedidoDetalle>()
                //{
                //    new PedidoDetalle
                //    {
                //        IdProducto = 1,
                //        Cantidad = 10,
                //        ValorVenta = 8,
                //        Eliminado = false
                //    },
                //    new PedidoDetalle
                //    {
                //        IdProducto = 2,
                //        Cantidad = 10,
                //        ValorVenta = 16,
                //        Eliminado = false
                //    }
                //},
                //PedidoFechas = new List<PedidoFecha>() { 
                //    new PedidoFecha { 
                //        Fecha = new DateTime(2023, 4, 7),
                //        Activo = false,
                //        DiaSemana = "Lunes",
                //        HoraMinuto = new TimeSpan(8,0,0),
                //    },
                //    new PedidoFecha {
                //        Fecha = new DateTime(2023, 4, 8),
                //        Activo = false,
                //        DiaSemana = "Martes",
                //        HoraMinuto = new TimeSpan(8,0,0),
                //    },
                //    new PedidoFecha {
                //        Fecha = new DateTime(2023, 4, 9),
                //        Activo = false,
                //        DiaSemana = "Miercoles",
                //        HoraMinuto = new TimeSpan(8,0,0),
                //    }
                //}
            };

            //var objPedidoBL = new PedidoBL();
            //var objResult = objPedidoBL.Registrar(pedido);
            var objPedidoDA = new PedidoDA();
            var objResult = objPedidoDA.Registrar(pedido);
            Assert.AreEqual(objResult, 1);
        }
    }
}