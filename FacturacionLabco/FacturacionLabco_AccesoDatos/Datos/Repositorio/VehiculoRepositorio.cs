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
                    Text = c.Nombre,
                    Value = c.Id.ToString()

                });

            }

            if (obj == WC.MarcaNombre)
            {
                return _db.marca.Select(c => new SelectListItem
                {
                    Text = c.Nombre_Marca,
                    Value = c.Id.ToString()

                });

            }

            return null;


        }
    }
}
