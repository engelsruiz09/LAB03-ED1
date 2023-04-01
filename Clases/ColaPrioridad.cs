using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ColaPrioridad<T>
    {
        private readonly List<ColaPrioridadNode<T>> heap;

        public ColaPrioridad()
        {
            heap = new List<ColaPrioridadNode<T>>();
        }

        private void Swap(int indice1, int indice2)//creamos una funcion swap para intercambiar 
        {
            var temp = heap[indice1];
            heap[indice1] = heap[indice2];
            heap[indice2] = temp;
        }
        public bool IsEmpty()
        {
            return heap.Count == 0; //si esta vacio el heap
        }

        public void UPHEAP(T data, int prioridad) //si el elemento es mas grande que su padre entonces se intercambian y se aplica para el padre, sino termina.
        {
            List<T> lista = new List<T>();
            int indiceactual = heap.Count - 1;
            int indicepadre = (indiceactual - 1) / 2; //la posicion del padre es ( i - 1 )/2

            //segun el encolar se agrega un nuevo nodo al final del heap
            var nuevonodo = new ColaPrioridadNode<T>(data, prioridad, lista);
            heap.Add(nuevonodo);

            //segun las propiedades del heap hay que reorganizar para mantener la propiedad de prioridad

            //hacemos una condicion para que se reorganize en caso de no cumplir con la propiedad
            while(indiceactual > 0 && heap[indicepadre].Prioridad > heap[indiceactual].Prioridad)
            {
                Swap(indiceactual, indicepadre); //intercambiamos los nodos
                indiceactual = indicepadre;//tambien se tiene que actualizar los indices
                indicepadre = (indiceactual - 1) / 2;
            }
        }

        public T DOWNHEAP()//si alguno de los hijos es mas grande que el elemento, entonces intercambiar con el mas grande de ellos. sino termino.
        {
            int indiceactual = 0;
            int indicehijoizquierdo = (indiceactual * 2) + 1; // posi de sus hijos (2 * i + 1)
            int indicehijoderecho = (indicehijoizquierdo * 2) + 2;//(2 * i + 2)
            //consiste en llevar el ultimo al primer lugar 
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola de prioridad se encuentra vacia");
            }
            T mayorprioridad = heap[0].Data; //creamos para obtener el elemento de mayor prioridad

            int ultimoindice = heap.Count - 1;//creamos estas 3 lineas para poder reemplazar el nodo de mayor prioridad con el ultimo nodo
            heap[0] = heap[ultimoindice];
            heap.RemoveAt(ultimoindice);

            //con esto volvemos a reorganizar el heap para mantener su propiedad
            while (true)
            {
                int indicehijomenor = indicehijoizquierdo;

                if (indicehijoderecho < ultimoindice && heap[indicehijoderecho].Prioridad < heap[indicehijoizquierdo].Prioridad)
                {
                    indicehijomenor = indicehijoderecho;
                }

                if (indicehijomenor >= ultimoindice || heap[indiceactual].Prioridad <= heap[indicehijomenor].Prioridad)
                {
                    break;
                }

                //hacemos el intercambio de los nodos
                Swap(indiceactual, indicehijomenor);
                //con este intercambio tambien tenemos que actualizar los indices
                indiceactual = indicehijomenor;
                indicehijoizquierdo = (indiceactual * 2) + 1;
                indicehijoderecho = (indicehijoizquierdo * 2) + 2;

            }
            return mayorprioridad;//y por ultimo retornamos el de mayor prioridad 
        }
        public List<T> GetList()
        {
            List<T> lista = new List<T>();
            foreach (var nodo in heap)
            {
                lista.Add(nodo.Data);
            }
            return lista;
        }


    }
}
