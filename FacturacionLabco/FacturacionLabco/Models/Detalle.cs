using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionLabco.Models
{
    public class Detalle
    {
        [Key]
        public int Id { get; set; }

        public float Monto { get; set; }

        public int Cantidad { get; set; }

        //Foregin key

        public int IDProducto { get; set; }
        [ForeignKey("IDProducto")]
        public virtual Producto? Producto { get; set; }

        public int IDServicio { get; set; }
        [ForeignKey("IDServicio")]
        public virtual Servicio? Servicio { get; set; }
    }
}
