using Microsoft.AspNetCore.Mvc;
using FacturacionLabco.Datos;
using FacturacionLabco.Models;

namespace FacturacionLabco.Controllers
{
    public class MarcaController : Controller
    {
        private readonly AplicationDbContext _db;

        public MarcaController(AplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Marca> lista = _db.marca;
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
        public IActionResult Crear(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _db.marca.Add(marca);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }

            var obj = _db.marca.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _db.marca.Update(marca);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(marca);
        }
    }
}
