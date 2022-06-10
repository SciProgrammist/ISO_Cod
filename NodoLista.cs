using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PEDG01T
{
    class NodoLista
    {
        private object dato;
        private NodoLista siguiente;

        public object Dato { get => dato; set => dato = value; }
        public NodoLista Siguiente { get => siguiente; set => siguiente = value; }

        //constructor con 2 parametros
        public NodoLista(object dato, NodoLista sigNodo)
        {
            this.dato = dato;
            siguiente = sigNodo;
        }

        //constructor con 1 parametro
        public NodoLista(object dato) : this(dato, null) { }
    }
}
