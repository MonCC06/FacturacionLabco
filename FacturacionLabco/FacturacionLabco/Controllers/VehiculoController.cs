using FacturacionLabco_AccesoDatos;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_AccesoDatos.Migrations;
using FacturacionLabco_Models;
using FacturacionLabco_Models.ViewModels;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

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

            ViewBag.Clientes = listacliente;

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
            //validamos el modelo
            if (ModelState.IsValid)
            {
                //ahora validamos si es o no un nuevo ingreso o si se trata de una actualizacion 
                if (vehiculoVM.Vehiculo.Id == 0)
                {

                    _vehRepo.Agregar(vehiculoVM.Vehiculo);
                }
                else
                {
                    //se actualiza si el ID es mayor a cero
                    var objProducto = _vehRepo.ObtenerPrimero(p => p.Id == vehiculoVM.Vehiculo.Id, isTracking: false);   //Obtenemos el producto que queremos editar 



                    _vehRepo.Actualizar(vehiculoVM.Vehiculo);

                }

                _vehRepo.Grabar();
                return RedirectToAction("Index");
            }//ESTA LLAVE PERTENCE AL IF DEL ModelIsValidate


            vehiculoVM.ClienteLista = _vehRepo.ObtenerTodosDropDownList(WC.ClienteNombre);
            vehiculoVM.MarcaLista = _vehRepo.ObtenerTodosDropDownList(WC.MarcaNombre);


            return View(vehiculoVM);//si el modelo no es validado o sea no es correcto retornamos a la vista el objeto

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