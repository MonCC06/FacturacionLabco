﻿using FacturacionLabco_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {

        void Actualizar(Cliente cliente);

        IEnumerable<Cliente> GetClienteList();
    }
}
