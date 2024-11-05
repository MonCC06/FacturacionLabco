using FacturacionLabco_Models;
using FacturacionLabco_AccesoDatos.Datos.Repositorio;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

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

        public void Actualizar(Migrations.Marca marca)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Migrations.Marca entidad)
        {
            throw new NotImplementedException();
        }

        public Migrations.Marca ObtenerPrimero(Expression<Func<Migrations.Marca, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            throw new NotImplementedException();
        }

        public Migrations.Marca ObtenerPrimero(Expression<Func<Migrations.Marca, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Migrations.Marca> ObtenerTodos(Expression<Func<Migrations.Marca, bool>> filtro = null, Func<IQueryable<Migrations.Marca>, IOrderedQueryable<Migrations.Marca>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Migrations.Marca> ObtenerTodos(Expression<Func<Migrations.Marca, bool>> filtro = null, Func<IQueryable<Migrations.Marca>, IOrderedQueryable<Migrations.Marca>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            throw new NotImplementedException();
        }

        public void Remover(Migrations.Marca entidad)
        {
            throw new NotImplementedException();
        }

        public void RemoverRango(IEnumerable<Migrations.Marca> entidad)
        {
            throw new NotImplementedException();
        }

        Migrations.Marca IRepositorio<Migrations.Marca>.Obtener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
