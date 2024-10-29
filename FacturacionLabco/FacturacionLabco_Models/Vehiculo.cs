using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionLabco_Models
{
    public class Vehiculo
    {
        public Vehiculo()
        {

        }

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Nombre del Modelo es obligatorio")]
        public string NombreModelo { get; set; }

        [Required(ErrorMessage = "Año del vehículo es obligatorio")]
        public string Anno { get; set; }

        [Required(ErrorMessage = "VIN  del vehículo es obligatorio")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Placa del vehículo es obligatorio")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Es necesario indicar si la distancia recorrida es en millas o kilometros")]
        public bool TipoDistancia { get; set; } // true = Millas, false = Kilómetros

        [Required(ErrorMessage = "Distancia es obligatoria")]
        public double DistanciaRecorrida { get; set; } // Distancia ingresada 

        public double ObtenerDistanciaEnKilometros()
        {
            return TipoDistancia ? DistanciaRecorrida * 1.60934 : DistanciaRecorrida;
        }

        //Foreing key

        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }


        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public virtual Marca? Marca { get; set; }
    }
}
