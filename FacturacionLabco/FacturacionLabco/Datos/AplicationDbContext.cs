using FacturacionLabco.Models;
using Microsoft.EntityFrameworkCore;

namespace FacturacionLabco.Datos
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        //Aca iremos Creando basados en el modelo las respectivas tablas en la bd 

        public DbSet<Cliente> clientes { get; set; }

        public DbSet<Marca> marca { get; set; }

        public DbSet<Producto> producto { get; set; }

        public DbSet<Servicio> servicio { get; set; }

        public DbSet<Trabajador> trabajador { get; set; }

        public DbSet<Factura> factura { get; set; }

        public DbSet<Detalle> detalle { get; set; }

        public DbSet<Vehiculo> vehiculo { get; set; }


    }
}
