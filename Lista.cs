using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PEDG01T
{
    public class Lista
    {
        private NodoLista firstNodo;
        private NodoLista lastNodo;

        //constructor de la lista
        public Lista()
        {
            firstNodo = lastNodo = null;
        }

        public bool IsEmpty => firstNodo == null;

        //agrega un nodo al final de la lista
        public void Add(object dato)
        {
            if (IsEmpty)
                firstNodo = lastNodo = new NodoLista(dato);
            else
                lastNodo = lastNodo.Siguiente = new NodoLista(dato);
        }

        //agrega un nodo en un indice especifico base 0
        public void AddToIndex(object dato, int i)
        {
            NodoLista aux = new NodoLista(dato);
            if (IsEmpty)
                firstNodo = lastNodo = aux;
            else
            {
                NodoLista puntero = firstNodo;
                if (i == 0)
                {
                    firstNodo = aux;
                    aux.Siguiente = puntero;
                }
                else
                {
                    for (int j = 1; j <= i; j++ )
                    {
                        puntero = puntero.Siguiente;
                        if (puntero.Siguiente == null)
                            break;
                    }
                    NodoLista next;
                    next = puntero.Siguiente;
                    puntero.Siguiente = aux;
                    aux.Siguiente = next;
                }
            }
        }

        //selecciona un nodo en un indice especifico base 0
        public object ElementAtIndex(int i)
        {
            if (IsEmpty)
                return null;
            else
            {
                NodoLista puntero = firstNodo;
                if (i == 0)
                {
                    return firstNodo.Dato;
                }
                else
                {
                    for (int j = 1; j <= i; j++)
                    {
                        puntero = puntero.Siguiente;
                        if (puntero.Siguiente == null)
                            break;
                    }
                    return puntero.Dato;
                }
            }
        }

        //elimina el nodo especificado, retorna true si se elimino el elemento
        public bool Remove(object dato)
        {
            bool deleted = false;
            if (!IsEmpty)
            {
                NodoLista aux = new NodoLista(dato);
                if (aux.Dato == firstNodo.Dato)
                {
                    firstNodo = firstNodo.Siguiente;
                    deleted = true;
                }
                else
                {
                    NodoLista puntero = firstNodo;
                    while (puntero.Siguiente != null)
                    {

                        if (aux.Dato == puntero.Siguiente.Dato)
                        {
                            NodoLista ayuda = puntero.Siguiente.Siguiente;
                            puntero.Siguiente = ayuda;
                            deleted = true;
                            break;
                        }
                        puntero = puntero.Siguiente;
                    }
                }
            }
            return deleted;
        }

        //método que elimina todos los nodos de la lista
        public void Clear()
        {
            if (!IsEmpty)
            {
                firstNodo = lastNodo = null;
            }
        }

        //conierte la lisa a un array
        public object[] ListToArray()
        {
            object[] items = new object[Count()];

            if (!IsEmpty)
            {
                NodoLista puntero;
                puntero = firstNodo;

                items[0] = puntero.Dato;
                int contador = 0;
                while (puntero.Siguiente != null)
                {
                    contador++;
                    puntero = puntero.Siguiente;
                    items[contador] = puntero.Dato;
                }
            }
            return items;
        }

        //metodo para conocer la cantidad de elemtos
        public int Count()
        {
            int count = 0;
            if (!IsEmpty)
            {
                NodoLista puntero;
                puntero = firstNodo;

                count = 1;
                while (puntero.Siguiente != null)
                {
                    count++;
                    puntero = puntero.Siguiente;
                }
            }
            return count;
        }

    }
}
