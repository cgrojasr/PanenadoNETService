﻿using CR.Panenado.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Panenado.DA
{
    public class PedidoDA
    {
        private readonly DbPaneandoContext dc;
        public PedidoDA() { 
            dc = new DbPaneandoContext();
        }


        public int Registrar(Pedido objPedido)
        {
            dc.Pedidos.Add(objPedido);
            dc.SaveChanges();
            return objPedido.IdPedido;
        }
    }
}
