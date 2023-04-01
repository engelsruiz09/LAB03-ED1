namespace Clases
{
    public class ColaPrioridadNode<T>
    {
        public T Data { get; set; }
        public int Prioridad {get; set;}
        private List<T> lista_misma_prioridad;
        public ColaPrioridadNode(T data, int prioridad, List<T> list)
        {
            Data = data;
            Prioridad = prioridad;
            lista_misma_prioridad = list;
        }
    }
}