using FacturacionLabco_AccesoDatos;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using FacturacionLabco_Models.ViewModels;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturacionLabco.Controllers
{
    public class VehiculoController : Controller
    {

        private readonly IVehiculoRepositorio _vehRepo;
        private readonly IMarcaRepositorio _marRepo;
        private readonly IClienteRepositorio _cliRepo;

        public VehiculoController(IVehiculoRepositorio vehRepo, IMarcaRepositorio marRepo, IClienteRepositorio cliRepo)//recibe nuestro contexto de BD
        {
            //    _db = db;
            _vehRepo = vehRepo;
            _marRepo = marRepo;
            _cliRepo = cliRepo;

        }
        public IActionResult Index()
        {
            IEnumerable<Vehiculo> lista = _vehRepo.ObtenerTodos(incluirPropiedades: "Marca,Cliente");
            
            IEnumerable<Cliente> listacliente = _cliRepo.GetClienteList();
            IEnumerable<Marca> listamarca = _marRepo.GetMarcaList();

            ViewBag.Clientes = listacliente;
            ViewBag.Marcas = listamarca;

            return View(lista);
        }



        public IActionResult Upsert(int? Id)
        {

            VehiculoVM vehiculoVM = new VehiculoVM()
            {
                Vehiculo = new Vehiculo(),

                ClienteLista = _vehRepo.ObtenerTodosDropDownList(WC.ClienteNombre),
                MarcaLista = _vehRepo.ObtenerTodosDropDownList(WC.MarcaNombre)
            };


            if (Id == null)
            {
                //crearemos un nuevo producto cuando no recibamos un ID

                return View(vehiculoVM);

            }
            else
            {
                vehiculoVM.Vehiculo = _vehRepo.Obtener(Id.GetValueOrDefault());
                if (vehiculoVM.Vehiculo == null)
                {
                    return NotFound();
                }
                return View(vehiculoVM);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(VehiculoVM vehiculoVM)
        {
            if (ModelState.IsValid)
            {
                if (vehiculoVM.Vehiculo.Id == 0)
                {
                    _vehRepo.Agregar(vehiculoVM.Vehiculo);
                }
                else
                {
                    var objProducto = _vehRepo.ObtenerPrimero(p => p.Id == vehiculoVM.Vehiculo.Id, isTracking: false);
                    _vehRepo.Actualizar(vehiculoVM.Vehiculo);
                }

                try
                {
                    _vehRepo.Grabar();
                }
                catch (DbUpdateException ex)
                {
                    var innerMessage = ex.InnerException?.Message ?? ex.Message;
                    // Puedes lanzar una excepción para que la veas en la pantalla, o hacer un log
                    throw new Exception($"Error al guardar en BD: {innerMessage}");
                }
            }

            // Si el modelo no es válido, devolvé algún error que podás manejar con JS
            return RedirectToAction("Index");
        }

        // ACA NO SOLAMENTE ELIMINAMOS EL PRODUCTO , SINO TBM LA IMG ASOCIADA A ESTE
        //GET


        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();
            }

            Vehiculo vehiculo = _vehRepo.ObtenerPrimero(p => p.Id == id);    //aca traemos los datos del producto de
                                                                             //acuerdo con el ID que recibimos de la vista


            if (vehiculo == null)
            {
                //en caso de que no exista 
                return NotFound();
            }

            return View(vehiculo); //le retornamos a la vista aliminar los datos del producto a eliminar 

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                return NotFound();

            }

            _vehRepo.Remover(vehiculo);  //Ahora eliminamos el producto
            _vehRepo.Grabar();
            return RedirectToAction(nameof(Index));


        }



    }



}