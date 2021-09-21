using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CursoWebCoreMVC.Models;

namespace ProjCursoWEBDotNetCoreMVC.Data
{
    public class ProjCursoWEBDotNetCoreMVCContext : DbContext
    {
        public ProjCursoWEBDotNetCoreMVCContext (DbContextOptions<ProjCursoWEBDotNetCoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<CursoWebCoreMVC.Models.Medicamento> Medicamento { get; set; }

        public DbSet<CursoWebCoreMVC.Models.MaterialConsumo> MaterialConsumo { get; set; }

        public DbSet<CursoWebCoreMVC.Models.Enfermeiro> Enfermeiro { get; set; }
        public DbSet<CursoWebCoreMVC.Models.Hospital> Hospital { get; set; }
    }
}
