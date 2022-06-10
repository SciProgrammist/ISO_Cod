using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PEDG01T
{
    class Nodo
    {
        private Pedido info;
        private Nodo siguiete;

        public Pedido Info
        {
            get { return info; }
            set { info = value; }
        }


        public Nodo Siquiente
        {
            get { return siguiete; }
            set { siguiete = value; }
        }
    }
}
