using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using FacturacionLabco_Utilidades;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            //throw new NotImplementedException();
            if (obj == WC.ClienteNombre)
            {
                return _db.cliente.Select(c => new SelectListItem
                {
                    Text = c.Nombre + " " + c.PrimerApellido + " " + c.SegundoApellido,
                    Value = c.Id.ToString()
                });
            }

            if (obj == WC.MarcaNombre)
            {
                return _db.Marca.Select(m => new SelectListItem
                {
                    Text = m.Nombre_Marca,
                    Value = m.Id.ToString()
                });
            }

            return null;
        }

        public IEnumerable<Vehiculo> GetVehiculoList()
        {
            return _db.vehiculo;
        }
    }
}
