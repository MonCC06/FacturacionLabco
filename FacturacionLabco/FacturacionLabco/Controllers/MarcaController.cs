﻿using FacturacionLabco_AccesoDatos;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace FacturacionLabco.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaRepositorio _marRepo;

        public MarcaController(IMarcaRepositorio marRepo)//recibe nuestro contexto de BD
        {
            //    _db = db;
            _marRepo = marRepo;

        }


        public IActionResult Index()
        {
            IEnumerable<Marca> lista = _marRepo.ObtenerTodos();

            return View(lista);
        }

        //Get
        public IActionResult Crear()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Marca marca)
        {

            if (ModelState.IsValid)
            {
                _marRepo.Agregar(marca);
                _marRepo.Grabar();
                TempData[WC.Exitosa] = "Marca creada exitosamente";
                return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index
            }
            TempData[WC.Error] = "Error al crear nueva marca";
            return View(marca);
        }


        //GET EDITAR QUE RECIBE DE LA VISTA EL ID DE LA CAT A EDITAR
        public IActionResult Editar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            var obj = _marRepo.Obtener(Id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Marca marca)
        {

            if (ModelState.IsValid)
            {
                _marRepo.Actualizar(marca);
                _marRepo.Grabar();
                return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index
            }
            return View(marca);
        }



        //GET ELIMINAR
        public IActionResult Eliminar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();

            }
            var obj = _marRepo.Obtener(Id.GetValueOrDefault());

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST ELIMINAR


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Marca marca)
        {

            if (marca == null)
            {
                return NotFound();
            }
            _marRepo.Remover(marca);
            _marRepo.Grabar();
            return RedirectToAction(nameof(Index)); //esto es para que ne redirigir al index

        }



    }
}
