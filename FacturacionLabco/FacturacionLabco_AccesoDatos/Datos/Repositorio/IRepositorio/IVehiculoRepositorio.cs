﻿using FacturacionLabco_Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio
{
    public interface IVehiculoRepositorio : IRepositorio<Vehiculo>
    {
        void Actualizar(Vehiculo vehiculo);

        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);
    }
}