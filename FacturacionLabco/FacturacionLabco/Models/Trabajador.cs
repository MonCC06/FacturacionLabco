using System.ComponentModel.DataAnnotations;
namespace FacturacionLabco.Models
{
    public class Trabajador
    {
        public int Id_Trabajador { get; set; }

        [Required(ErrorMessage = "Nombre del trabajador obligatorio")]
        public string Nombre { get; set; }
    }
}
