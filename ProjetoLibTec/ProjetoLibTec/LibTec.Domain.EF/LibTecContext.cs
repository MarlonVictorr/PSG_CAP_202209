using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Domain.EF
{
    public partial class LibTecContext : DbContext
    {

        DbSet<Autor> Autores { get; set; } = null!;

        DbSet<AutorItem> AutorItems { get; set; } = null!;

        DbSet<Emprestimo> Emprestimos { get; set; } = null!;

        DbSet<Item> Items{ get; set; } = null!;

        DbSet<Reserva> Reservas{ get; set; } = null!;

        DbSet<TipoItem> TipoItems{ get; set; } = null!;

        DbSet<TipoStatusEmprestimo> TipoStatusEmprestimos{ get; set; } = null!;

        DbSet<TipoStatusReserva> TipoStatusReservas { get; set; } = null!;

        DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;

        DbSet<Usuario> Usuarios { get; set; } = null!;

        public LibTecContext() : base()
        {}

        public LibTecContext(DbContextOptions<LibTecContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AutorItem>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoItem>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoStatusEmprestimo>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoStatusReserva>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
