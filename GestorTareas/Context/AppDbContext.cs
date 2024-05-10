using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
