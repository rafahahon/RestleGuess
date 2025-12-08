using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestleGuess.Models;

namespace RestleGuess.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Escolha> Escolhas { get; set; }

    public virtual DbSet<Perguntum> Pergunta { get; set; }

    public virtual DbSet<Personagem> Personagems { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Escolha>(entity =>
        {
            entity.HasKey(e => e.IdEscolha).HasName("PK__Escolha__36206D9310CCC903");
        });

        modelBuilder.Entity<Perguntum>(entity =>
        {
            entity.HasKey(e => e.IdPergunta).HasName("PK__Pergunta__6DC6D9A7FA4BEA0A");
        });

        modelBuilder.Entity<Personagem>(entity =>
        {
            entity.HasKey(e => e.IdPersonagem).HasName("PK__Personag__4C5EDFB31AD0D97D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF9712BB1F3E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
