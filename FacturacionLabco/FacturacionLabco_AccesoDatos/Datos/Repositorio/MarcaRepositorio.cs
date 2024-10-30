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
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly AplicationDbContext _db;

        public MarcaRepositorio(AplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Marca marca)
        {
            var catAnterior = _db.Marca.FirstOrDefault(c => c.Id == marca.Id); // Debería ser 'Categorias'.
            if (catAnterior != null)
            {
                catAnterior.Nombre_Marca = marca.Nombre_Marca;
            }
        }
    }
}
