using System.ComponentModel.DataAnnotations;

namespace FacturacionLabco_Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        //nombre

        [Required(ErrorMessage = "Nombre de marca obligatorio")]
        public string Nombre_Marca { get; set; }


    }
}
