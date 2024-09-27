using System.ComponentModel.DataAnnotations;

namespace FacturacionLabco.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        //nombre

        [Required(ErrorMessage = "Nombre de marca obligatorio")]
        public string Nombre_Marca { get; set; }


        [Required(ErrorMessage = "Estado de la marca obligatorio")]
        public Boolean Estado_Marca { get; set; }
    }
}
