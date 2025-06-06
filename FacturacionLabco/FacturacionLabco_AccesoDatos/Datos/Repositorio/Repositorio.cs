﻿using Microsoft.EntityFrameworkCore;
using System;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        // Definimos el acceso a nuestro DBContext.
        private readonly AplicationDbContext _db; // Tenemos que aplicar de nuevo el acceso al DBContext.
        internal DbSet<T> dbSet; // Conjunto de datos para la entidad T.

        // Inicializamos nuestras variables en el constructor.
        public Repositorio(AplicationDbContext db)
        {
            _db = db; // Asignamos el DBContext.
            this.dbSet = _db.Set<T>(); // Configuramos el DbSet para la entidad T.
        }

        // Método para agregar una nueva entidad.
        public void Agregar(T entidad)
        {
            dbSet.Add(entidad);
        }

        // Método para guardar los cambios en la base de datos.
        public void Grabar()
        {
            _db.SaveChanges();
        }

        // Método para obtener una entidad por su ID.
        public T Obtener(int id)
        {
            return dbSet.Find(id);
        }

        // Método para obtener el primer dato que cumple con un filtro específico.
        public T ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet; // Comenzamos la consulta en el DbSet.

            if (filtro != null)
            {
                query = query.Where(filtro); // Aplicamos el filtro si está definido.
            }
            if (incluirPropiedades != null)
            {
                // Incluimos propiedades relacionadas en la consulta.
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // Por ejemplo: "Categoria,TipoAplicacion".
                }
            }
            if (!isTracking)
            {
                query = query.AsNoTracking(); // Deshabilitamos el seguimiento de cambios si isTracking es false.
            }
            return query.FirstOrDefault(); // Devolvemos el primer resultado o null si no hay coincidencias.
        }

        // Método para obtener todos los datos que cumplan con un filtro específico.
        public IEnumerable<T> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet; // Comenzamos la consulta en el DbSet.

            if (filtro != null)
            {
                query = query.Where(filtro); // Aplicamos el filtro si está definido.
            }
            if (incluirPropiedades != null)
            {
                // Incluimos propiedades relacionadas en la consulta.
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // Por ejemplo: "Categoria,TipoAplicacion".
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query); // Ordenamos los resultados si la función orderBy está definida.
            }
            if (!isTracking)
            {
                query = query.AsNoTracking(); // Deshabilitamos el seguimiento de cambios si isTracking es false.
            }
            return query.ToList(); // Devolvemos la lista de resultados.
        }

        // Método para eliminar una entidad existente.
        public void Remover(T entidad)
        {
            dbSet.Remove(entidad);
        }




        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }



    }
}
