using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionLabco.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }

        public string Estado { get; set; }

        public float Total { get; set; }

        public float Subtotal { get; set; }

        public float Iva { get; set; }

        public float Descuento { get; set; }

        public DateTime Fecha { get; set; }

        //Foregin key

        public int IDDetalle { get; set; }
        [ForeignKey("IDDetalle")]
        public virtual Detalle? Detalle { get; set; }

        public int IDTrabajador { get; set; }
        [ForeignKey("IDTrabajador")]
        public virtual Trabajador? Trabajador { get; set; }

        public int IDCliente { get; set; }
        [ForeignKey("IDCliente")]
        public virtual Cliente? Cliente { get; set; }
    }
}
