using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LAB03_ED1_G.Models
{
    public class Paciente
    {
        public delegate int Prioridad(string Sexo, DateTime? FechaNac, string Especializacion, string Ingreso, int PrioridadModelo);
        [Display(Name = "Nombres")]
        [Required]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name = "FDNacimiento")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? FDNacimiento { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Display(Name = "Especializacion")]
        [Required]
        public string Especializacion { get; set; }

        [Display(Name = "MIngreso")]
        [Required]
        public string MIngreso { get; set; }

        [Display(Name = "PrioridadModelo")]
        [Required]
        public int PrioridadModelo { get; set; }

        public Prioridad Delegado = new Prioridad(Prioraty); // creacion del delegado para el calculo de la prioridad

        public static int Prioraty(string Sexo, DateTime? FechaNac, string Especializacion, string Ingreso, int PrioridadModelo)
        {
            int edad=CalcularEdad(FechaNac);
            int Prioridad = 0;
            if (Sexo == "Masculino")
            {
                Prioridad += 3;
            }
            else
            {
                Prioridad += 5; // femenino
            }

            if (edad >= 0 && edad <= 5)// edad entre 0 - 5 
            {
                Prioridad += 8; 
            }
            else if (edad >= 6 && edad <= 17)//edad entre 6 - 17 
            {
                Prioridad += 5;
            }
            else if (edad >= 18 && edad <= 49)//edad entre 18 - 49
            {
                Prioridad += 3;
            }
            else if (edad >= 50 && edad <= 69)//edad entre 50 - 69
            {
                Prioridad += 8;
            }
            else if (edad >= 70) //los mayores a 70
            {
                Prioridad += 10;
            }

            if (Especializacion == "Traumatología Interna")
            {
                Prioridad += 3;
            }
            else if (Especializacion == "Traumatología Expuesta")
            {
                Prioridad += 8;
            }
            else if (Especializacion == "Ginecología")
            {
                Prioridad += 5;
            }
            else if (Especializacion == "Cardiología")
            {
                Prioridad += 10;
            }
            else if (Especializacion == "Neumología")
            {
                Prioridad += 8;
            }

            if (Ingreso == "Ambulancia")
            {
                Prioridad += 5;
            }
            else
            {
                Prioridad += 3; //asistido
            }
            return Prioridad;
        }
        public static int CalcularEdad(DateTime? fecha)
        {
            if (!fecha.HasValue) // Comprobar si el objeto es nulo
            {
                return 0; // Devolver un valor predeterminado o lanzar una excepción, dependiendo de tus necesidades
            }

            DateTime hoy = DateTime.Today;
            DateTime fechaReal = fecha.Value; // Convertir el objeto nullable a un objeto DateTime real
            int años = hoy.Year - fechaReal.Year;

            if (hoy < fechaReal.AddYears(años))
                años--;

            return años;
        }


    }
}
