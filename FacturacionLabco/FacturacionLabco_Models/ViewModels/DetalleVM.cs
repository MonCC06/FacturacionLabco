using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FacturacionLabco_Models.ViewModels
{
    public class DetalleVM
    {
        public Detalle Detalle { get; set; }

        public IEnumerable<SelectListItem>? ProductoLista { get; set; }
    }
}
