using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using FacturacionLabco_Models.ViewModels;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionLabco.Controllers
{
    public class DetalleController : Controller
    {
        private readonly IDetalleRepositorio _detalleRepo;
        public DetalleController(IDetalleRepositorio detalleRepo)
        {
            _detalleRepo = detalleRepo;
        }
        public IActionResult Index()
        {
            IEnumerable<Detalle> lista = _detalleRepo.ObtenerTodos(incluirPropiedades: "Producto");

            return View();
        }

        //GET

        public IActionResult Upsert(int? Id)
        {

            DetalleVM detalleVM = new DetalleVM()
            {
                Detalle = new Detalle(),
                ProductoLista = _detalleRepo.ObtenerTodosDropDownList(WC.ProductoNombre)
            };


            if (Id == null)
            {
                //crearemos un nuevo producto cuando no recibamos un ID

                return View(detalleVM);

            }
            else
            {
                detalleVM.Detalle = _detalleRepo.Obtener(Id.GetValueOrDefault());
                if (detalleVM.Detalle == null)
                {
                    return NotFound();
                }
                return View(detalleVM);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DetalleVM detalleVM)
        {
            //validamos el modelo
            if (ModelState.IsValid)
            {
                //esto para poder obtener la imagen que nos envia la vista
                //ahora validamos si es o no un nuevo ingreso o si se trata de una actualizacion 
                if (detalleVM.Detalle.Id == 0)
                {
                    _detalleRepo.Agregar(detalleVM.Detalle);
                }
                else
                {
                    //se actualiza si el ID es mayor a cero
                    var objDetalle = _detalleRepo.ObtenerPrimero(d => d.Id == detalleVM.Detalle.Id, isTracking: false);   //Obtenemos el producto que queremos editar 


                    //ya luego actualizamos el producto

                    _detalleRepo.Actualizar(detalleVM.Detalle);

                }

                _detalleRepo.Grabar();
                return RedirectToAction("Index");
            }//ESTA LLAVE PERTENCE AL IF DEL ModelIsValidate


            detalleVM.ProductoLista = _detalleRepo.ObtenerTodosDropDownList(WC.ProductoNombre);


            return View(detalleVM);//si el modelo no es validado o sea no es correcto retornamos a la vista el objeto

        }

        // ACA NO SOLAMENTE ELIMINAMOS EL PRODUCTO , SINO TBM LA IMG ASOCIADA A ESTE
        //GET


        public IActionResult Eliminar(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();
            }

            Detalle detalle = _detalleRepo.ObtenerPrimero(d => d.Id == id);    //aca traemos los datos del producto de
                                                                               //acuerdo con el ID que recibimos de la vista


            if (detalle == null)
            {
                //en caso de que no exista 
                return NotFound();
            }

            return View(detalle); //le retornamos a la vista aliminar los datos del producto a eliminar 

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Detalle detalle)
        {
            if (detalle == null)
            {
                return NotFound();

            }

            _detalleRepo.Remover(detalle);  //Ahora eliminamos el producto
            _detalleRepo.Grabar();
            return RedirectToAction(nameof(Index));
        }
    }
}
