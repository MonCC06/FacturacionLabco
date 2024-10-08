using Microsoft.AspNetCore.Mvc;
using FacturacionLabco.Datos;
using FacturacionLabco.Models;
using FacturacionLabco.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FacturacionLabco.Controllers
{
    public class FacturaController : Controller
    {
        private readonly AplicationDbContext _db;

        public FacturaController(AplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Factura> lista = _db.factura;

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

            IEnumerable<SelectListItem> detalleDropDown = _db.detalle.Select(d => new SelectListItem
            {

                Text = d.Producto == null ? d.Servicio.ToString() : // Si ProductoId es null, muestra Servicio
                d.Servicio == null ? d.Producto.ToString() : // Si ServicioId es null, muestra Producto
                $"{d.Producto} - {d.Servicio}",
                Value = d.Id.ToString()
            });

            ViewBag.detalleDropDown = detalleDropDown;

            Factura factura = new Factura();

            FacturaVM facturaVM = new FacturaVM()
            {
                Factura = new Factura(),
                ClienteLista = _db.clientes.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }),
                DetalleLista = _db.detalle.Select(d => new SelectListItem
                {
                    Text = d.Producto == null ? d.Servicio.ToString() :
                    d.Servicio == null ? d.Producto.ToString() :
                    $"{d.Producto} - {d.Servicio}",
                    Value = d.Id.ToString()
                })
            };



            if (Id == null)
            {
                return View(facturaVM);
            }
            else
            {
                facturaVM.Factura = _db.factura.Find(Id);
                if (facturaVM == null)
                {
                    return NotFound();
                }
                return View(facturaVM);
            }
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FacturaVM facturaVM)
        {
            if (ModelState.IsValid)
            {
                if (facturaVM.Factura.Id == 0)// id es 0, no hay objeto , hay que crear uno nuevo 
                {
                    _db.factura.Add(facturaVM.Factura);
                }
                else
                {
                    // si hay un producto ya creado y hay que actualizar 
                    _db.factura.Update(facturaVM.Factura);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }//cierre modelo no valido 
            return View(facturaVM);

        }

        //Get
        public IActionResult Eliminar(int? Id) 
        {
            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            Factura factura = _db.factura.Include(d => d.Detalle)
               .Include(t => t.Trabajador).Include(c => c.Cliente).
               FirstOrDefault(f => f.Id == Id);

            if (factura != null)
            {

                return NotFound();

            }

            return View(factura);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] //Datos encriptados
        public IActionResult Eliminar(Factura factura)
        {
            if (factura == null)
            {

                return NotFound();

            }

            _db.factura.Remove(factura);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
