using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionLabco.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del Modelo es obligatorio")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Año es obligatorio")]
        public string Anno { get; set; }

        [Required(ErrorMessage = "VIN es obligatorio")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "La placa es obligatoria")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Tipo de distancia es obligatorio")]
        public string TipoDeDistancia { get; set; }

        [Required(ErrorMessage = "Distancia recorrida es obligatoria")]
        public string DistanciaRecorrida { get; set; }

        //Foregin key

        public int IDCliente { get; set; }
        [ForeignKey("IDCliente")]
        public virtual Cliente? Cliente { get; set; }

        public int IDMarca { get; set; }
        [ForeignKey("IDMarca")]
        public virtual Marca? Marca { get; set; }
    }
}
