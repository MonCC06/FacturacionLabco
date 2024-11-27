using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using FacturacionLabco_Models.ViewModels;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionLabco.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaRepositorio _facturaRepo;
        private readonly ITrabajadorRepositorio _traRepo;
        private readonly IClienteRepositorio _cliRepo;
        private readonly IProductoRepositorio _proRepo;
        public FacturaController(IFacturaRepositorio facturaRepo, ITrabajadorRepositorio traRepo,
            IClienteRepositorio cliRepo, IProductoRepositorio proRepo)
        {
            _facturaRepo = facturaRepo;
            _traRepo = traRepo;
            _cliRepo = cliRepo;
            _proRepo = proRepo;
        }
        public IActionResult Index()
        {
            IEnumerable<Factura> lista = _facturaRepo.ObtenerTodos(incluirPropiedades: "Trabajador,Cliente,Vehiculo");
            IEnumerable<Trabajador> listaTrabajadores = _traRepo.GetTrabajadorList();
            IEnumerable<Cliente> listaclientes = _cliRepo.GetClienteList();
            IEnumerable<Producto> listaproductos = _proRepo.GetProductoList();

            ViewBag.Trabajadores = listaTrabajadores;
            ViewBag.Clientes = listaclientes;
            ViewBag.Productos = listaproductos;
            return View(lista);
        }

        //GET

        public IActionResult Upsert(int? Id)
        {

            FacturaVM facturaVM = new FacturaVM()
            {
                Factura = new Factura(),
                DetalleLista = _facturaRepo.ObtenerTodosDropDownList(WC.DetalleNombre),
                TrabajadorLista = _facturaRepo.ObtenerTodosDropDownList(WC.TrabajadorNombre),
                ClienteLista = _facturaRepo.ObtenerTodosDropDownList(WC.ClienteNombre),
                VehiculoLista = _facturaRepo.ObtenerTodosDropDownList(WC.VehiculoNombre)
            };


            if (Id == null)
            {
                //crearemos un nuevo producto cuando no recibamos un ID

                return View(facturaVM);

            }
            else
            {
                facturaVM.Factura = _facturaRepo.Obtener(Id.GetValueOrDefault());
                if (facturaVM.Factura == null)
                {
                    return NotFound();
                }
                return View(facturaVM);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FacturaVM facturaVM)
        {
            //validamos el modelo
            if (ModelState.IsValid)
            {
                //esto para poder obtener la imagen que nos envia la vista
                //ahora validamos si es o no un nuevo ingreso o si se trata de una actualizacion 
                if (facturaVM.Factura.Id == 0)
                {
                    _facturaRepo.Agregar(facturaVM.Factura);
                }
                else
                {
                    //se actualiza si el ID es mayor a cero
                    var objFactura = _facturaRepo.ObtenerPrimero(f => f.Id == facturaVM.Factura.Id, isTracking: false);   //Obtenemos el producto que queremos editar 


                    //ya luego actualizamos el producto

                    _facturaRepo.Actualizar(facturaVM.Factura);

                }

                _facturaRepo.Grabar();
                return RedirectToAction("Index");
            }//ESTA LLAVE PERTENCE AL IF DEL ModelIsValidate


            facturaVM.DetalleLista = _facturaRepo.ObtenerTodosDropDownList(WC.DetalleNombre);


            return View(facturaVM);//si el modelo no es validado o sea no es correcto retornamos a la vista el objeto

        }

        // ACA NO SOLAMENTE ELIMINAMOS EL PRODUCTO , SINO TBM LA IMG ASOCIADA A ESTE
        //GET


        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();
            }

            Factura factura= _facturaRepo.ObtenerPrimero(f => f.Id == id);    //aca traemos los datos del producto de
                                                                               //acuerdo con el ID que recibimos de la vista


            if (factura == null)
            {
                //en caso de que no exista 
                return NotFound();
            }

            return View(factura); //le retornamos a la vista aliminar los datos del producto a eliminar 

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Factura factura)
        {
            if (factura == null)
            {
                return NotFound();

            }

            _facturaRepo.Remover(factura);  //Ahora eliminamos el producto
            _facturaRepo.Grabar();
            return RedirectToAction(nameof(Index));
        }
    }
}
