using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_Models.ViewModels
{
    public class FacturaVM
    {
        public Factura Factura { get; set; }

        public IEnumerable<SelectListItem>? ClienteLista { get; set; }
        public IEnumerable<SelectListItem>? TrabajadorLista { get; set; }
        public IEnumerable<SelectListItem>? DetalleLista { get; set; }
        public IEnumerable<SelectListItem>? VehiculoLista { get; set; }
    }
}
