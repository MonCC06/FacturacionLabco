using FacturacionLabco_AccesoDatos;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionLabco.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteRepositorio _cliRepo;

        public ClienteController(IClienteRepositorio cliRepo)//recibe nuestro contexto de BD
        {
            //    _db = db;
            _cliRepo = cliRepo;

        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = _cliRepo.ObtenerTodos();

            return View(lista);
        }


        [HttpGet]
        public IActionResult ObtenerListaClientes()
        {

            return Json(new { data = _cliRepo.ObtenerTodos() });

        }

        //Get
        public IActionResult Crear()
        {


            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                _cliRepo.Agregar(cliente);
                _cliRepo.Grabar();
                TempData[WC.Exitosa] = "Cliente cread@ exitosamente";
                return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index
            }
            TempData[WC.Error] = "Error al crear nuev@ cliente";
            return View(cliente);
        }


        //GET EDITAR QUE RECIBE DE LA VISTA EL ID DE LA CAT A EDITAR
        public IActionResult Editar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            var obj = _cliRepo.Obtener(Id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                _cliRepo.Actualizar(cliente);
                _cliRepo.Grabar();
                return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index
            }
            return View(cliente);
        }



        //GET ELIMINAR
        public IActionResult Eliminar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            var obj = _cliRepo.Obtener(Id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST ELIMINAR


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            var cliente = _cliRepo.Obtener(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _cliRepo.Remover(cliente);
            _cliRepo.Grabar();
            return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index

        }




    }
}
