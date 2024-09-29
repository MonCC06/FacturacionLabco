using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacturacionLabco.Models.ViewModels
{
    public class VehiculoVM
    {
        public Vehiculo Vehiculo { get; set; }

        public IEnumerable<SelectListItem>? ClienteLista { get; set; }
        public IEnumerable<SelectListItem>? MarcaLista { get; set; }
    }
}
