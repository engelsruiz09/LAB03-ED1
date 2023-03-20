namespace Clases
{
    public class Node<T>
    {
        public Node<T> NPadre; //creacion de los nodos padre,izquierdo y derecho 
        public Node<T> NIzquierdo;
        public Node<T> NDerecho;
        

        public T Key;
        public int Priority; // la prioridad que nos brinda la practica 

        public Node() { } //constructor
        public Node(T key,int priority)
        {
            Key = key;
            Priority = priority;
        }
    }
}