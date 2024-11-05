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

            var catAnterior = _db.producto.FirstOrDefault(c => c.Id_Producto == producto.Id_Producto); // Debería ser 'Categorias'.
            if (catAnterior != null)
            {
                catAnterior.Descripcion_Producto = producto.Descripcion_Producto;



            }



        }

    }

}
