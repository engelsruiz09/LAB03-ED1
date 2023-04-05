namespace Clases
{
    public class ColaPrioridadNode<T>
    {
        public T Data { get; set; }
        public int Prioridad {get; set;}

        public ColaPrioridadNode(T data, int prioridad)
        {
            Data = data;
            Prioridad = prioridad;
        }
    }
}
