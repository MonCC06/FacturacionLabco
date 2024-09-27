using FacturacionLabco.Datos;
using FacturacionLabco.Models;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionLabco.Controllers
{
    public class ServicioController : Controller
    {
        private readonly AplicationDbContext _db;

        public ServicioController(AplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Servicio> lista = _db.servicio;
            return View();
        }

        //Get
        public IActionResult Crear()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _db.servicio.Add(servicio);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicio);
        }

        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }

            var obj = _db.servicio.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _db.producto.Update(producto);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(producto);
        }

        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }

            var obj = _db.producto.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                return NotFound();
            }
            _db.producto.Remove(producto);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
