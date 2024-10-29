using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacturacionLabco_Models.ViewModels
{
    public class ProductoUsuarioVM
    {

        public ProductoUsuarioVM()
        {
            ProductoLista = new List<Producto>();
        }

        //pROPIEDAD PARA OBTENER LOS DATOS DEL CLIENTE QUE TENGA ESA SESION
        public UsuarioAplicacion UsuarioAplicacion { get; set; }
        //LA LISTA DE PRODUCTOS QUE TENGA ESE CLIENTE
        public IList<Producto> ProductoLista { get; set; }
    }
}
