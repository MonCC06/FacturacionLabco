using System;
using FacturacionLabco_Models;
using System.Collections.Generic;
using FacturacionLabco_AccesoDatos.Datos.Repositorio;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly AplicationDbContext _db;


        public ClienteRepositorio(AplicationDbContext db) : base(db) //aca necesitamos implementar el db padre 
        {
            _db = db;
        }
        public void Actualizar(Cliente cliente)
        {
            //  throw new NotImplementedException();


            var tipoAnterior = _db.cliente.FirstOrDefault(t => t.Id == cliente.Id);
            if (tipoAnterior != null)
            {

                tipoAnterior.Nombre = cliente.Nombre;

            }
        }
    }




}

