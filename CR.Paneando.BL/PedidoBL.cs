using CR.Panenado.DA;
using CR.Panenado.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Paneando.BL
{
    public class PedidoBL
    {
        private readonly PedidoDA objPedidoDA;
        public PedidoBL() { 
            objPedidoDA= new PedidoDA();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objPedido"></param>
        /// <returns>Retorna los datos completos del pedido registrado</returns>
        public Pedido Registrar(Pedido objPedido)
        {
            try
            {
                if (objPedido != null)
                {
                    objPedido.Fecha = DateTime.Now;
                    objPedido.Estado = 1;
                    for (DateTime fecha = objPedido.FechaInicio; fecha <= objPedido.FechaFin; fecha = fecha.AddDays(1))
                    {
                        var objPedidoFecha = new PedidoFecha();
                        objPedidoFecha.Fecha = fecha;
                        objPedidoFecha.HoraMinuto = objPedido.HoraMinuto;
                        objPedidoFecha.Activo = true;
                        objPedido.PedidoFechas.Add(objPedidoFecha);
                    }
                    var idPedido = objPedidoDA.Registrar(objPedido);
                    objPedido.IdPedido = idPedido;
                    return objPedido;
                }
                else {
                    throw new Exception("No existen datos del pedido");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
