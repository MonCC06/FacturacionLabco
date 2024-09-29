using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacturacionLabco.Models.ViewModels
{
    public class FacturaVM
    {
        public Factura Factura { get; set; }

        public IEnumerable<SelectListItem>? DetalleLista { get; set; }
        public IEnumerable<SelectListItem>? TrabaadorLista { get; set; }
        public IEnumerable<SelectListItem>? ClienteLista { get; set; }
    }
}
