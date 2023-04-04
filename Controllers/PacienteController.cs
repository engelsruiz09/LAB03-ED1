using LAB03_ED1_G.Models;
using LAB03_ED1_G.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System;
using static LAB03_ED1_G.Models.Paciente;

namespace LAB03_ED1_G.Controllers
{
    public class PacienteController : Controller
    {
        private IWebHostEnvironment Environment;
        public PacienteController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {

            //return View();
            return View(Singleton.Instance.Pacientes.GetList());     // arreglar despues
        }

        public ActionResult Delete()
        {
            try
            {
                if (Singleton.Instance.Pacientes.IsEmpty())
                {
                    ViewData["Message"] = "No hay pacientes para atender";
                }
                Singleton.Instance.Pacientes.Eliminacion();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewData["Message"] = "Algo sucedio mal";
                return RedirectToAction(nameof(Index));

            }
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
                prioridad = newPaciente.Delegado(newPaciente.Sexo, newPaciente.FDNacimiento, newPaciente.Especializacion, newPaciente.MIngreso);
                Singleton.Instance.Pacientes.UPHEAP(newPaciente, prioridad);
                //agregar metodo add al heap 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CargarArchivo(IFormFile File)
        {
            string Nombre = "", Apellido = "", Sexo = "", Especializacion = "", MetodoIngreso = "";
            DateTime FechaNac;

            try
            {

                if (File != null)
                {
                    string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string FileName = Path.GetFileName(File.FileName);
                    string FilePath = Path.Combine(path, FileName);
                    using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                    {
                        File.CopyTo(stream);
                    }
                    using (TextFieldParser csvFile = new TextFieldParser(FilePath))
                    {

                        csvFile.CommentTokens = new string[] { "#" };
                        csvFile.SetDelimiters(new string[] { "," });
                        csvFile.HasFieldsEnclosedInQuotes = true;

                        csvFile.ReadLine();

                        while (!csvFile.EndOfData)
                        {
                            string[] fields = csvFile.ReadFields();
                            Nombre = Convert.ToString(fields[0]);
                            Apellido = Convert.ToString(fields[1]);
                            FechaNac = Convert.ToDateTime(fields[2]);
                            Sexo = Convert.ToString(fields[3]);
                            Especializacion = Convert.ToString(fields[4]);
                            MetodoIngreso = Convert.ToString(fields[5]);
                            Paciente nuevopaciente = new Paciente
                            {
                                Nombres = Nombre,
                                Apellidos = Apellido,
                                FDNacimiento = FechaNac,
                                Sexo = Sexo,
                                Especializacion = Especializacion,
                                MIngreso = MetodoIngreso,

                            };
                            Singleton.Instance.Pacientes.UPHEAP(nuevopaciente, Paciente.Prioraty(nuevopaciente.Sexo, nuevopaciente.FDNacimiento, nuevopaciente.Especializacion, nuevopaciente.MIngreso));// arreglar cuando este el heap
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewData["Message"] = "Algo sucedio mal";
                return RedirectToAction(nameof(Index));

            }
        }
    }
}
