using System.ComponentModel.DataAnnotations;

namespace FacturacionLabco.Models
{
    public class Servicio
    {
        [Key]
        public int Id_Servicio { get; set; }

        [Required(ErrorMessage = "Nombre del Servicio es obligatorio")]
        public string Descripcion_Servicio { get; set; }


        [Required(ErrorMessage = "Precio del Servicio es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "el Precio tiene que ser mayor a cero")]
        public float Precio_Servicio { get; set; }


        [Required(ErrorMessage = "Estado del Servicio obligatorio")]
        public Boolean Estado_Producto { get; set; }
    }
}
