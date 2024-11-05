using FacturacionLabco_Models;
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
            _db.Update(trabajador);
            var catAnterior = _db.trabajador.FirstOrDefault(c => c.Id == trabajador.Id); // Debería ser 'Categorias'.
            if (catAnterior != null)
            {
                catAnterior.Nombre = trabajador.Nombre;
            }




        }


    }
}
