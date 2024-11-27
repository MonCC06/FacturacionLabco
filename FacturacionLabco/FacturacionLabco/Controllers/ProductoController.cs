using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionLabco.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepositorio _proRepo;

        public ProductoController(IProductoRepositorio proRepo)//recibe nuestro contexto de BD
        {
            //    _db = db;
            _proRepo = proRepo;

        }

        public IActionResult Index()
        {
            IEnumerable<Producto> lista = _proRepo.ObtenerTodos();

            return View(lista);
        }

        //Get
        public IActionResult Crear()
        {


            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {

            if (ModelState.IsValid)
            {
                _proRepo.Agregar(producto);
                _proRepo.Grabar();
                TempData[WC.Exitosa] = "Producto creado exitosamente";
                return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index
            }
            TempData[WC.Error] = "Error al crear un nuevo producto";
            return View(producto);
        }


        //GET EDITAR QUE RECIBE DE LA VISTA EL ID DE LA CAT A EDITAR
        public IActionResult Editar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            var obj = _proRepo.Obtener(Id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {

            if (ModelState.IsValid)
            {
                _proRepo.Actualizar(producto);
                _proRepo.Grabar();
                TempData[WC.Exitosa] = "Producto creado exitosamente";
                return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index
            }
            TempData[WC.Error] = "Error al crear un nuevo producto";
            return RedirectToAction(nameof(Index));
        }



        //GET ELIMINAR
        public IActionResult Eliminar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            var obj = _proRepo.Obtener(Id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST ELIMINAR


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int Id_Producto)
        {
            var producto = _proRepo.Obtener(Id_Producto);
            if (producto == null)
            {
                return NotFound();
            }
            _proRepo.Remover(producto);
            _proRepo.Grabar();
            return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index

        }
    }
}