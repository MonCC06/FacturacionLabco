using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El estado de la factura")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Total de la factura es obligatorio")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Subtotal de la factura es obligatorio")]
        public double Subtotal { get; set; }

        [Required(ErrorMessage = "Iva de la factura es obligatorio")]
        public double Iva { get; set; }

        [Required(ErrorMessage = "Fecha de la factura es obligatorio")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Nota de la factura es obligatoria")]
        public string Nota { get; set; }

        [Required(ErrorMessage = "Nota interna de la factura es obligatoria")]
        public string Nota_Interna { get; set; }


        //Foreing key

        public int DetalleID { get; set; }

        [ForeignKey("DetalleID")]
        public virtual Detalle? Detalle { get; set; }


        public int TrabajadorID { get; set; }

        [ForeignKey("TrabajadorID")]
        public virtual Trabajador? Trabajador { get; set; }

        public int ClienteID { get; set; }

        [ForeignKey("ClienteID")]
        public virtual Cliente? Cliente { get; set; }

        public int VehiculoID { get; set; }

        [ForeignKey("VehiculoID")]
        public virtual Vehiculo? Vehiculo { get; set; }
    }
}
