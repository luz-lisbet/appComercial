using Microsoft.EntityFrameworkCore;
using appComercial.Models;

namespace appComercial.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> producto { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Docente> Docente { get; set; }

    }
}