using FacturacionLabco_Models;
using FacturacionLabco_AccesoDatos.Datos.Repositorio;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class TrabajadorRepositorio : Repositorio<Trabajador>, ITrabajadorRepositorio
    {
        private readonly AplicationDbContext _db;
        public TrabajadorRepositorio(AplicationDbContext db) : base(db) //aca necesitamos implementar el db padre 
        {
            _db = db;
        }
        public void Actualizar(Trabajador trabajador)
        {
            var trabajadorDb = _db.trabajador.FirstOrDefault(t => t.Id == trabajador.Id);

            if (trabajadorDb != null)
            {
                trabajadorDb.Cedula = trabajador.Cedula;
                trabajadorDb.Correo = trabajador.Correo;
                trabajadorDb.Nombre = trabajador.Nombre;
                trabajadorDb.PrimerApellido = trabajador.PrimerApellido;
                trabajadorDb.SegundoApellido = trabajador.SegundoApellido;
                trabajadorDb.Telefono = trabajador.Telefono;
            }
        }


    }
}
