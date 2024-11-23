using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {

        private readonly AplicationDbContext _db;
        public ProductoRepositorio(AplicationDbContext db) : base(db) //aca necesitamos implementar el db padre 
        {
            _db = db;
        }
        public void Actualizar(Producto producto)
        {

            var proAnterior = _db.producto.FirstOrDefault(p => p.Id_Producto == producto.Id_Producto);
            if (proAnterior != null)
            {
                proAnterior.Descripcion_Producto = producto.Descripcion_Producto;
                proAnterior.Stock_Producto = producto.Stock_Producto;
                proAnterior.Precio_Producto = producto.Precio_Producto;
            }



        }

    }

}
