using CR.Panenado.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Panenado.DA
{
    public class ClienteDA
    {
        private readonly DbPaneandoContext dc;
        public ClienteDA()
        {
            dc = new DbPaneandoContext();
        }

        public Cliente? Autenticar(string email, string password)
        {
            return dc.Clientes.First(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

        public int Registrar(Cliente objCliente) { 
            dc.Clientes.Add(objCliente);
            dc.SaveChanges();

            return objCliente.IdCliente;
        }
    }
}
