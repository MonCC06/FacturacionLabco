using FacturacionLabco.Datos;
using FacturacionLabco.Models;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionLabco.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AplicationDbContext _db;

        //Metodo constructor que recibe parametros de la clase DBContext
        public ClienteController(AplicationDbContext db)
        {
            _db = db;

        }
        //Metodos que se ejecutan desde la vista 
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = _db.clientes; //Accede a los clientes por medio del _db y trae a todos los objetos del modelo cliente y los almacena en la lista


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
        public IActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.clientes.Add(cliente);//Guarde los datos en la BD
                _db.SaveChanges();//Se salven los datos
                return RedirectToAction(nameof(Index));//Una vez los datos fueron insertados, muestre el index con el cliente insertado
            }
            return View(cliente);
        }



        //Get del action EDITAR
        public IActionResult Editar(int? Id) //Recibe el id del cliente a editar, puede ser que venga nuelo, por eso el ?
        {
            if (Id == null || Id == 0)
            { return View(); }

            var obj = _db.clientes.Find(Id); //Busque el cliente con el id y traiga el objeto de ese id
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //Post Envia informacion
        [HttpPost]
        [ValidateAntiForgeryToken] //Datos encriptados
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _db.clientes.Update(cliente);//Actualiza los datos en la BD
                _db.SaveChanges();//Se salven los datos
                return RedirectToAction(nameof(Index));//Una vez los datos fueron insertados, muestre el index con la categoria insertada
            }

            return View(cliente);
        }


        //Get del action Eliminar
        public IActionResult Eliminar(int? Id) //Recibe el id del cliente a eliminar, puede ser que venga nuelo, por eso el ?
        {
            if (Id == null || Id == 0)
            { return View(); }

            var obj = _db.clientes.Find(Id); //Busque el cliente con el id y traiga el objeto de ese id
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //Post Envia informacion
        [HttpPost]
        [ValidateAntiForgeryToken] //Datos encriptados
        public IActionResult Eliminar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                return NotFound();
            }

            _db.clientes.Remove(cliente);//Actualiza los datos en la BD
            _db.SaveChanges();//Se salven los datos
            return RedirectToAction(nameof(Index));//Una vez los datos fueron insertados, muestre el index del cliente insertada

        }
    }
}
