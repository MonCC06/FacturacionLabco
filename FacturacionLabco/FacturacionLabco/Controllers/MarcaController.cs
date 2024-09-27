using Microsoft.AspNetCore.Mvc;
using FacturacionLabco.Datos;


namespace FacturacionLabco.Controllers
{
    public class MarcaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
