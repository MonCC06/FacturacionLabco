using FacturacionLabco_AccesoDatos;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionLabco.Controllers
{
    public class TrabajadorController : Controller
    {

        private readonly ITrabajadorRepositorio _traRepo;

        public TrabajadorController(ITrabajadorRepositorio traRepo)//recibe nuestro contexto de BD
        {
            //    _db = db;
            _traRepo = traRepo;

        }
        public IActionResult Index()
        {
            IEnumerable<Trabajador> lista = _traRepo.ObtenerTodos();

            return View(lista);
        }

        //Get
        public IActionResult Crear()
        {


            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Trabajador trabajador)
        {

            if (ModelState.IsValid)
            {
                _traRepo.Agregar(trabajador);
                _traRepo.Grabar();
                TempData[WC.Exitosa] = "Trabajador cread@ exitosamente";
                return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index
            }
            TempData[WC.Error] = "Error al crear nuev@ trabajador";
            return View(trabajador);
        }


        //GET EDITAR QUE RECIBE DE LA VISTA EL ID DE LA CAT A EDITAR
        public IActionResult Editar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            var obj = _traRepo.Obtener(Id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Trabajador trabajador)
        {

            if (ModelState.IsValid)
            {
                _traRepo.Actualizar(trabajador);
                _traRepo.Grabar();
                return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index
            }
            return View(trabajador);
        }



        //GET ELIMINAR
        public IActionResult Eliminar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            var obj = _traRepo.Obtener(Id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST ELIMINAR


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Trabajador trabajador)
        {

            if (trabajador == null)
            {
                return NotFound();
            }
            _traRepo.Remover(trabajador);
            _traRepo.Grabar();
            return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index

        }
    }
}
