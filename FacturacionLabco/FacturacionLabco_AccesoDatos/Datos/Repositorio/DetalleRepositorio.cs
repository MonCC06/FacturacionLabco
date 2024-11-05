using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class DetalleRepositorio : Repositorio<Detalle>, IDetalleRepositorio
    {


        private readonly AplicationDbContext _db;
        public DetalleRepositorio(AplicationDbContext db) : base(db) //aca necesitamos implementar el db padre 
        {
            _db = db;
        }
        public void Actualizar(Detalle detalle)
        {
            _db.Update(detalle);
        }

    }




}

