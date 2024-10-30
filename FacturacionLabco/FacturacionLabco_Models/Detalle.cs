using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_Models
{
    public class Detalle
    {
        [Key]
        public int Id { get; set; }

        public double Monto { get; set; }

        [Required(ErrorMessage = "Total de la factura es obligatorio")]
        public int Cantidad { get; set; }

        //Foreing key

        public int ProductoID { get; set; }

        [ForeignKey("ProductoID")]
        public virtual Producto? Producto { get; set; }

        public int ServicioID { get; set; }

        [ForeignKey("ServicioID")]
        public virtual Servicio? Servicio { get; set; }
    }
}
