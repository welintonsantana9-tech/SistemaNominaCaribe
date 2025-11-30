using Microsoft.EntityFrameworkCore;
using SistemaNominaCaribe.Modelos;

namespace SistemaNominaCaribe.Datos
{
    public class NominaContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // CAMBIO: Ahora usa SQLite y crea un archivo llamado nomina.db
            optionsBuilder.UseSqlite("Data Source=nomina.db");
        }
    }
}