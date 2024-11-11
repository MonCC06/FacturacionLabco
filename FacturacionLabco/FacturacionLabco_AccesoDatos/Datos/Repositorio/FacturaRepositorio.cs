using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using FacturacionLabco_Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class FacturaRepositorio : Repositorio<Factura>, IFacturaRepositorio
    { 
        private readonly AplicationDbContext _db;

        public FacturaRepositorio(AplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Factura factura)
        {
            _db.Update(factura);
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            //  throw new NotImplementedException();

            if (obj == WC.ClienteNombre)
            {
                return _db.cliente.Select(c => new SelectListItem
                {
                    Text = c.Cedula,
                    Value = c.Id.ToString()

                });

            }


            if (obj == WC.TrabajadorNombre)
            {
                return _db.trabajador.Select(t => new SelectListItem
                {
                    Text = t.Nombre,
                    Value = t.Id.ToString()

                });

            }

            if (obj == WC.DetalleNombre)
            {
                return _db.detalle
                    .Where(d => d.Producto != null) // Filtra los detalles que tienen un producto asociado
                    .Select(d => new SelectListItem
                    {
                        Text = d.Producto.Descripcion_Producto, // Asume que `Nombre` es la propiedad que quieres mostrar
                        Value = d.Id.ToString()
                    })
                    .ToList();
            }


            if (obj == WC.VehiculoNombre)
            {
                return _db.vehiculo.Select(t => new SelectListItem
                {
                    Text = t.Placa,
                    Value = t.Id.ToString()

                });

            }


            return null;

        }
    }
}
