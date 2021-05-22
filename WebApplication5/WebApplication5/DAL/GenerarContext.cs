using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Prestamos.Models;

namespace Prestamos.DAL
{
    public class GenerarContext : DbContext
    {
        public GenerarContext() : base("Conexion") { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
              

    }
}