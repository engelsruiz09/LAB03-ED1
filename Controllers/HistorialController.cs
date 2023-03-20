using LAB03_ED1_G.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace LAB03_ED1_G.Controllers
{
    public class HistorialController : Controller
    {
        public IActionResult Index()
        {
            return View(Singleton.Instance.Historial);
        }
    }
}
