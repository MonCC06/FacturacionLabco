using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class VehiculoRepositorio : Repositorio<Vehiculo>, IVehiculoRepositorio
    {

        private readonly AplicationDbContext _db;
        public VehiculoRepositorio(AplicationDbContext db) : base(db) //aca necesitamos implementar el db padre 
        {
            _db = db;
        }
        public void Actualizar(Vehiculo vehiculo)
        {
            _db.Update(vehiculo);
        }
    }
}
