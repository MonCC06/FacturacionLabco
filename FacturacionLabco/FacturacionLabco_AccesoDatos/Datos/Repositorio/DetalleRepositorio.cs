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
        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            //  throw new NotImplementedException();

            if (obj == WC.ProductoNombre)
            {
                return _db.producto.Select(c => new SelectListItem
                {
                    Text = c.Descripcion_Producto,
                    Value = c.Id_Producto.ToString()

                });

            }

            return null;

        }
    }

}
