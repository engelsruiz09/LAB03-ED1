namespace LAB03_ED1_G.Models.Data
{
    public class Singleton // para garantizar que una clase tenga solo una instancia y proporcionar un punto de acceso global a dicha instancia
    {
        private static Singleton _instance = null; //_instance para almacenar la unica instancia de la clase, se evita que se creen instancia adicionales de la clase desde otros lugares del codigo siendo la clase privada

        public static Singleton Instance // proporciona un punto de acceso global a esta instancia
        {
            get { //get comprueba si la instancia ya existe, si no existe se crea una nueva instancia utilizando el constructor privado de la clase y se le asigna a _instance si ya existe una instancia se devuelve la instancia existente.
                if (_instance == null) _instance = new Singleton();
                return _instance;
            } //garantiza que solo se cree una instancia de la clase singleton y que se pueda acceder a ella desde cualquier lugar del codigo usando Instance
        }

        public Clases.Heap<Paciente> Pacientes = new Clases.Heap<Paciente>(); // instancia de nuestra clase generica heap contiene objetos de tipo paciente, Pacientes = almacenear una coleccion de pascientes
        public List<Paciente> Historial = new List<Paciente>(); // instancia de una lista generica de objetos de tipo paciente, Historial = una lista para almacenar el historial de pacientes en un orden.
    }
}
