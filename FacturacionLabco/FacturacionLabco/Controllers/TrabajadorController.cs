using FacturacionLabco.Datos;
using FacturacionLabco.Models;
using Microsoft.AspNetCore.Mvc;


namespace FacturacionLabco.Controllers
{
    public class TrabajadorController : Controller
    {

        private readonly AplicationDbContext _db;

        //Metodo constructor que recibe parametros de la clase DBContext
        public TrabajadorController(AplicationDbContext db)
        {
            _db = db;

        }
        //Metodos que se ejecutan desde la vista 
        public IActionResult Index()
        {
            IEnumerable<Trabajador> lista = _db.trabajadores; //Accede a los clientes por medio del _db y trae a todos los objetos del modelo cliente y los almacena en la lista


            return View(lista);
        }

        //Get del action crear
        public IActionResult Crear()
        {
            return View();
        }

        //Post Envia informacion
        [HttpPost]
        [ValidateAntiForgeryToken] //Datos encriptados
        public IActionResult Crear(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _db.trabajadores.Add(trabajador);//Guarde los datos en la BD
                _db.SaveChanges();//Se salven los datos
                return RedirectToAction(nameof(Index));//Una vez los datos fueron insertados, muestre el index con el cliente insertado
            }
            return View(trabajador);
        }



        //Get del action EDITAR
        public IActionResult Editar(int? Id) //Recibe el id del cliente a editar, puede ser que venga nuelo, por eso el ?
        {
            if (Id == null || Id == 0)
            { return View(); }

            var obj = _db.trabajadores.Find(Id); //Busque el cliente con el id y traiga el objeto de ese id
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //Post Envia informacion
        [HttpPost]
        [ValidateAntiForgeryToken] //Datos encriptados
        public IActionResult Editar(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _db.trabajadores.Update(trabajador);//Actualiza los datos en la BD
                _db.SaveChanges();//Se salven los datos
                return RedirectToAction(nameof(Index));//Una vez los datos fueron insertados, muestre el index con la categoria insertada
            }

            return View(trabajador);
        }


        //Get del action Eliminar
        public IActionResult Eliminar(int? Id) //Recibe el id del cliente a eliminar, puede ser que venga nuelo, por eso el ?
        {
            if (Id == null || Id == 0)
            { return View(); }

            var obj = _db.trabajadores.Find(Id); //Busque el cliente con el id y traiga el objeto de ese id
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //Post Envia informacion
        [HttpPost]
        [ValidateAntiForgeryToken] //Datos encriptados
        public IActionResult Eliminar(Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                return NotFound();
            }

            _db.trabajadores.Remove(trabajador);//Actualiza los datos en la BD
            _db.SaveChanges();//Se salven los datos
            return RedirectToAction(nameof(Index));//Una vez los datos fueron insertados, muestre el index del cliente insertada

        }
    }
}
