using FacturacionLabco_Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio
{
    public interface IDetalleRepositorio : IRepositorio<Detalle>
    {

        void Actualizar(Detalle detalle);

        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);
    }
}
