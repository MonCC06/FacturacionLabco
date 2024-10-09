using FacturacionLabco.Datos;
using FacturacionLabco.Models.ViewModels;
using FacturacionLabco.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FacturacionLabco.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly AplicationDbContext _db;

        public VehiculoController(AplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Vehiculo> lista = _db.vehiculo;

            return View(lista);
        }

        public IActionResult Upsert(int? Id)
        {

            IEnumerable<SelectListItem> clienteDropDown = _db.clientes.Select(c => new SelectListItem
            {
                Text = c.Nombre,
                Value = c.Id.ToString()
            });

            ViewBag.clienteDropDown = clienteDropDown;

            IEnumerable<SelectListItem> marcaDropDown = _db.marca.Select(m => new SelectListItem
            {

                Text = m.Nombre_Marca,
                Value = m.Id.ToString()
            });

            ViewBag.marcaDropDown = marcaDropDown;

            Vehiculo vehiculo = new Vehiculo();

            VehiculoVM vehiculoVM = new VehiculoVM()
            {
                Vehiculo = new Vehiculo(),
                ClienteLista = _db.clientes.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }),
                MarcaLista = _db.marca.Select(m => new SelectListItem
                {
                    Text = m.Nombre_Marca,
                    Value = m.Id.ToString()
                })
            };



            if (Id == null)
            {
                return View(vehiculoVM);
            }
            else
            {
                vehiculoVM.Vehiculo = _db.vehiculo.Find(Id);
                if (vehiculoVM == null)
                {
                    return NotFound();
                }
                return View(vehiculoVM);
            }
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(VehiculoVM vehiculoVM)
        {
            if (ModelState.IsValid)
            {
                if (vehiculoVM.Vehiculo.Id == 0)// id es 0, no hay objeto , hay que crear uno nuevo 
                {
                    _db.vehiculo.Add(vehiculoVM.Vehiculo);
                }
                else
                {
                    // si hay un producto ya creado y hay que actualizar 
                    _db.vehiculo.Update(vehiculoVM.Vehiculo);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }//cierre modelo no valido 
            return View(vehiculoVM);

        }

        //Get
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            Vehiculo vehiculo = _db.vehiculo.Include(c => c.Cliente)
               .Include(m => m.Marca).FirstOrDefault(v => v.Id == Id);

            if (vehiculo != null)
            {

                return NotFound();

            }

            return View(vehiculo);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] //Datos encriptados
        public IActionResult Eliminar(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {

                return NotFound();

            }

            _db.vehiculo.Remove(vehiculo);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
