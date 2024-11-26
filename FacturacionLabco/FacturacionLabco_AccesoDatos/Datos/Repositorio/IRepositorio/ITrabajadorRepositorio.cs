using FacturacionLabco_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio
{
    public interface ITrabajadorRepositorio : IRepositorio<Trabajador>
    {
        void Actualizar(Trabajador trabajador);
        IEnumerable<Trabajador> GetTrabajadorList();
    }
}
