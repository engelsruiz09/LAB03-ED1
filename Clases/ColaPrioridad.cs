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

        public void UPHEAP(T data, int prioridad)
        {
            int indiceactual = heap.Count; // Se agrega en la última posición
            heap.Add(new ColaPrioridadNode<T>(data, prioridad));

            while (indiceactual > 0)
            {
                int indicepadre = (indiceactual - 1) / 2;

                if (heap[indicepadre].Prioridad >= prioridad)
                {
                    break; // El nodo padre tiene menor o igual prioridad, no es necesario intercambiar
                }

                // Intercambiar el nodo actual con el nodo padre
                Swap(indiceactual, indicepadre);

                // Actualizar el índice del nodo actual
                indiceactual = indicepadre;
            }

            // Ordenar los nodos por orden de mayor a menor prioridad
            for (int i = heap.Count - 1; i > 0; i--)
            {
                Swap(0, i);

                int nuevoIndiceActual = 0;
                int indicehijoizquierdo = (nuevoIndiceActual * 2) + 1;
                int indicehijoderecho = (indicehijoizquierdo * 2) + 2;

                while (true)
                {
                    int indicehijomenor = indicehijoizquierdo;

                    if (indicehijoderecho < i && heap[indicehijoderecho].Prioridad > heap[indicehijoizquierdo].Prioridad)
                    {
                        indicehijomenor = indicehijoderecho;
                    }

                    if (indicehijomenor >= i || heap[nuevoIndiceActual].Prioridad >= heap[indicehijomenor].Prioridad)
                    {
                        break;
                    }

                    Swap(nuevoIndiceActual, indicehijomenor);

                    nuevoIndiceActual = indicehijomenor;
                    indicehijoizquierdo = (nuevoIndiceActual * 2) + 1;
                    indicehijoderecho = (indicehijoizquierdo * 2) + 2;
                }
            }
        }



        public T DOWNHEAP()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La cola de prioridad se encuentra vacia");
            }

            int ultimoindice = heap.Count - 1;
            T mayorprioridad = heap[ultimoindice].Data;

            heap[0] = heap[ultimoindice];
            heap.RemoveAt(ultimoindice);

            int indiceactual = 0;
            int indicehijoizquierdo = (indiceactual * 2) + 1;
            int indicehijoderecho = (indicehijoizquierdo * 2) + 2;

            while (true)
            {
                int indicehijomenor = indicehijoizquierdo;

                if (indicehijoderecho < heap.Count && heap[indicehijoderecho].Prioridad > heap[indicehijoizquierdo].Prioridad)
                {
                    indicehijomenor = indicehijoderecho;
                }

                if (indicehijomenor >= heap.Count || heap[indiceactual].Prioridad >= heap[indicehijomenor].Prioridad)
                {
                    break;
                }

                Swap(indiceactual, indicehijomenor);
                indiceactual = indicehijomenor;
                indicehijoizquierdo = (indiceactual * 2) + 1;
                indicehijoderecho = (indicehijoizquierdo * 2) + 2;
            }

            return mayorprioridad;
        }
        public List<T> GetListNoElimination()
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
