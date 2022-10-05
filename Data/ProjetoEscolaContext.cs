using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetosEscola.Models;

    public class ProjetoEscolaContext : DbContext
    {
        public ProjetoEscolaContext (DbContextOptions<ProjetoEscolaContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetosEscola.Models.Aluno> Aluno { get; set; } = default!;
        public DbSet<ProjetosEscola.Models.Professor> Professor { get; set; } = default!;
        public DbSet<ProjetosEscola.Models.Orientacao> Orientacao { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Orientacao>()
                .HasKey(pe => new { pe.Id });
            modelBuilder.Entity<Orientacao>()
                .HasOne(p => p.Aluno)
                .WithMany(pe => pe.Orientacao)
                .HasForeignKey(p => p.IdAluno);
            modelBuilder.Entity<Orientacao>()
                .HasOne(p => p.Professor)
                .WithMany(pe => pe.Orientacao)
                .HasForeignKey(p => p.IdProfessor);
        }

    }
