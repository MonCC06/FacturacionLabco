using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacturacionLabco.Models.ViewModels
{
    public class DetalleVM
    {
        public Detalle Detalle { get; set; }

        public IEnumerable<SelectListItem>? ProductoLista { get; set; }
        public IEnumerable<SelectListItem>? ServicioLista { get; set; }
    }
}
