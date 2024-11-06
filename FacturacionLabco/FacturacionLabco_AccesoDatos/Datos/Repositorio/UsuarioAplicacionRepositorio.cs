using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class UsuarioAplicacionRepositorio : Repositorio<UsuarioAplicacion>, IUsuarioAplicacion
    {

        private readonly AplicationDbContext _db;
        public UsuarioAplicacionRepositorio(AplicationDbContext db) : base(db) //aca necesitamos implementar el db padre 
        {
            _db = db;
        }
        public void Actualizar(UsuarioAplicacion usuarioAplicacion)
        {
            _db.Update(usuarioAplicacion);
        }
    }
}
