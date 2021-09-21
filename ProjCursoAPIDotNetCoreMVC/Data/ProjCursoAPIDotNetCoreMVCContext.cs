using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CursoWebCoreMVC.Models;

namespace ProjCursoAPIDotNetCoreMVC.Data
{
    public class ProjCursoAPIDotNetCoreMVCContext : DbContext
    {
        public ProjCursoAPIDotNetCoreMVCContext (DbContextOptions<ProjCursoAPIDotNetCoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<CursoWebCoreMVC.Models.Medicamento> Medicamento { get; set; }

        public DbSet<CursoWebCoreMVC.Models.MaterialConsumo> MaterialConsumo { get; set; }

        public DbSet<CursoWebCoreMVC.Models.Hospital> Hospital { get; set; }
        public DbSet<CursoWebCoreMVC.Models.Enfermeiro> Enfermeiro { get; internal set; }
    }
}
