using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_Models
{
    public class UsuarioAplicacion : IdentityUser
    { 
        public string NombreCompleto { get; set; }

    }
}
