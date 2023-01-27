using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Domain.EF
{
    public partial class AvaliarContext : DbContext
    {

        DbSet<Usuario> Usuarios { get; set; } = null!;

        DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;


        public AvaliarContext() : base()
        { }

        public AvaliarContext(DbContextOptions<AvaliarContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }   
}
