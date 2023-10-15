using Microsoft.EntityFrameworkCore;

namespace tarefa_mvc_lp.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) {}

        public DbSet<Peao> Peoes { get; set; }
        public DbSet<Empreiteira> Empreiteiras { get; set; }
        public DbSet<PeaoMestre> peoesMestres { get; set; }
        public DbSet<Obra> Obras { get; set; }
    }
}
