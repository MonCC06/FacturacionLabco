﻿using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio
{
    public class FacturaRepositorio : Repositorio<Factura>, IFacturaRepositorio
    { 
        private readonly AplicationDbContext _db;

        public FacturaRepositorio(AplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Factura factura)
        {
            _db.Update(factura);
        }
    }
}