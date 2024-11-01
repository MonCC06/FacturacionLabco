using System.ComponentModel.DataAnnotations;

namespace FacturacionLabco_Models
{
    public class Producto
    {
        [Key]
        public int Id_Producto { get; set; }

        [Required(ErrorMessage = "Nombre del Producto es obligatorio")]
        public string Descripcion_Producto { get; set; }


        [Required(ErrorMessage = "Precio del Producto es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "el Precio tiene que ser mayor a cero")]
        public float Precio_Producto { get; set; }

        [Required(ErrorMessage = "Stock del Producto es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "el Stock tiene que ser mayor a cero")]
        public float Stock_Producto { get; set; }

        public int tipo {  get; set; }
    }
}
