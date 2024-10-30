using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class ServicioRepositorio : Repositorio<Servicio>, IServicioRepositorio 
    {

        private readonly AplicationDbContext _db;

        public ServicioRepositorio(AplicationDbContext db): base(db) //Implementamos db context padre
        {
            _db = db;
        }
        public void Actualizar(Servicio servicio)
        {

            var serAnteriror = _db.servicio.FirstOrDefault(t => t.Id_Servicio == servicio.Id_Servicio);
            if (serAnteriror != null) 
            {
                serAnteriror.Descripcion_Servicio = servicio.Descripcion_Servicio;
            
            }   




        }
    


    }
}
