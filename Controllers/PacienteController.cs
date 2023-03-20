using LAB03_ED1_G.Models;
using LAB03_ED1_G.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace LAB03_ED1_G.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View(Singleton.Instance.Pacientes.GetList());
        }

        public ActionResult Create() 
        { 
            return View();
        
        }
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                int prioridad = 0;
                int edad = 0;
                DateTime aux = new DateTime();
                var newPaciente = new Paciente
                {
                    Nombres = collection["Nombres"],
                    Apellidos = collection["Apellidos"],
                    FDNacimiento = Convert.ToDateTime(collection["FDNacimiento"]),
                    Sexo = Convert.ToString(collection["Sexo"]),
                    Especializacion = Convert.ToString(collection["Especializacion"]),
                    MIngreso = Convert.ToString(collection["MIngreso"])
                };
                aux = Convert.ToDateTime(newPaciente.FDNacimiento);
                edad = DateTime.Today.AddTicks(-aux.Ticks).Year - 1;
                prioridad = newPaciente.Delegado(newPaciente.Sexo, edad, newPaciente.Especializacion, newPaciente.MIngreso);
                //Singleton.Instance.Pacientes.Add(newPaciente, DateTime.Now, prioridad);
                //agregar metodo add al heap 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
