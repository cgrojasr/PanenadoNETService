using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Paneando.BL
{
    public class Constants
    {
        public class PedidoEstado {
            public const int Cancelado = 0;
            public const int Registrado = 1;
            public const int Procesando = 2;
            public const int Pendiente = 3;
            public const int Enviado = 4;
            public const int Entregado = 5;
        }
    }
}
