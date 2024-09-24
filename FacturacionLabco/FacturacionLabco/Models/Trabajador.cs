using FacturacionLabco.Migrations;
using Humanizer.Localisation.TimeToClockNotation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionLabco.Models
{
    public class Trabajador
    {

        [Key]/*Indicamos cual es nuestro Primary Key*/
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre obligatorio")]
        public string Nombre { get; set; }

        //DESCRIPCION ES OBLIGATORIO
        [Required(ErrorMessage = "Cédula obligatoria")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Correo obligatorio")]
        public string Correo { get; set; }

        //DESCRIPCION ES OBLIGATORIO
        [Required(ErrorMessage = "Telefono obligatorio")]
        public string Telefono { get; set; }
    }
}
