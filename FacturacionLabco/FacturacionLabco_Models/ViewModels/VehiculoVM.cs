using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FacturacionLabco_Models.ViewModels
{
    public class VehiculoVM
    {
        public Vehiculo Vehiculo { get; set; }

        public IEnumerable<SelectListItem>? ClienteLista { get; set; }
        public IEnumerable<SelectListItem>? MarcaLista { get; set; }

    }
}
