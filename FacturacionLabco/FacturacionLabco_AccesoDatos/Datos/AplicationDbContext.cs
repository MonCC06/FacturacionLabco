using FacturacionLabco_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FacturacionLabco_AccesoDatos
{
    public class AplicationDbContext : IdentityDbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        //Aca iremos Creando basados' en el modelo las respectivas tablas en la bd 

        public DbSet<Cliente> cliente { get; set; }

        public DbSet<Marca> Marca { get; set; }

        public DbSet<Producto> producto { get; set; }

        public DbSet<Servicio> servicio { get; set; }

        public DbSet<Trabajador> trabajador { get; set; }

        public DbSet<Vehiculo> vehiculo { get; set; }


    }
}
