using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Heap<T>: ICloneable // para que funcione ICloneable hay que definir el metodo Clone que se utiliza para crear una copia superficial del objeto este caso clase Heap 
    {
        public object Clone()// para crear una copia superficial del objeto actual Heap y devuelve una referencia a esta copia
        {
            return this.MemberwiseClone();//la copia se crea utilizando el metodo MemberwiseClone que crea una copia superficial del objeto actual, copia todos los campos de la clase pero no realiza una copia profunda de los objetos que puedan estar almacenados en estos campo.
        }
        public Node<T> Raiz;// el nodo raiz generico
        public int Tcont; // el contador de las prioridades
        private List<T> listaOrdenada = new List<T>(); //asignar una nueva instancia de la lista generica a la variable listaordenada, inicialmente vacia, almacenar una coleccion de elementos de cualquier tipo.

        public Heap() { Tcont = 0; }

        public bool verificarvacio() { return Raiz == null ? true : false; } // si la raiz se encuentra vacia devolvemos verdadero caso contrario no este vacia devolvemos falso

        public bool verificarlleno() { return Tcont == 10 ? true : false; }// si el contador de prioridades llega a 10 devolvemos verdadero, para datos menores a 10 devolvemos falso.

        public List<T> GetList() //para obtener el recorrido InOrder en nuestra lista
        {
            listaOrdenada.Clear();
            InOrder(Raiz);
            return listaOrdenada;
        }
        private void InOrder(Node<T> nodo) //aplicamos el recorrido InOrder
        {
            if (nodo != null)
            {
                InOrder(nodo.NIzquierdo);
                listaOrdenada.Add(nodo.Key);
                InOrder(nodo.NDerecho);
            }
        }
        
        
    }
}
