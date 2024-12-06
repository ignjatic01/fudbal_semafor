using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace FudbalSemafor.Models;

public partial class SemaforDbContext : DbContext
{
    public SemaforDbContext()
    {
    }

    public SemaforDbContext(DbContextOptions<SemaforDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gol> Gols { get; set; }

    public virtual DbSet<Igrac> Igracs { get; set; }

    public virtual DbSet<Izmjena> Izmjenas { get; set; }

    public virtual DbSet<Karton> Kartons { get; set; }

    public virtual DbSet<KartonTip> KartonTips { get; set; }

    public virtual DbSet<Klub> Klubs { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<Pozicija> Pozicijas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Stadion> Stadions { get; set; }

    public virtual DbSet<Utakmica> Utakmicas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Gol>(entity =>
        {
            entity.HasKey(e => e.IdGol).HasName("PRIMARY");

            entity.ToTable("gol");

            entity.HasIndex(e => e.Igrac, "FK_gol_igrac_idx");

            entity.HasIndex(e => e.Klub, "FK_gol_klub_idx");

            entity.HasIndex(e => e.Utakmica, "FK_gol_utakmica_idx");

            entity.Property(e => e.IdGol).HasColumnName("idGol");
            entity.Property(e => e.Igrac).HasColumnName("igrac");
            entity.Property(e => e.Klub).HasColumnName("klub");
            entity.Property(e => e.Minut).HasColumnName("minut");
            entity.Property(e => e.Utakmica).HasColumnName("utakmica");

            entity.HasOne(d => d.IgracNavigation).WithMany(p => p.Gols)
                .HasForeignKey(d => d.Igrac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gol_igrac");

            entity.HasOne(d => d.KlubNavigation).WithMany(p => p.Gols)
                .HasForeignKey(d => d.Klub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gol_klub");

            entity.HasOne(d => d.UtakmicaNavigation).WithMany(p => p.Gols)
                .HasForeignKey(d => d.Utakmica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gol_utakmica");
        });

        modelBuilder.Entity<Igrac>(entity =>
        {
            entity.HasKey(e => e.IdIgrac).HasName("PRIMARY");

            entity.ToTable("igrac");

            entity.HasIndex(e => e.Klub, "FK_igrac_klub_idx");

            entity.HasIndex(e => e.Pozicija, "FK_igrac_pozicija_idx");

            entity.Property(e => e.IdIgrac).HasColumnName("idIgrac");
            entity.Property(e => e.BrojDresa).HasColumnName("brojDresa");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .HasColumnName("ime");
            entity.Property(e => e.Klub).HasColumnName("klub");
            entity.Property(e => e.Pozicija)
                .HasMaxLength(5)
                .HasColumnName("pozicija");
            entity.Property(e => e.Prezime)
                .HasMaxLength(50)
                .HasColumnName("prezime");

            entity.HasOne(d => d.KlubNavigation).WithMany(p => p.Igracs)
                .HasForeignKey(d => d.Klub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_igrac_klub");

            entity.HasOne(d => d.PozicijaNavigation).WithMany(p => p.Igracs)
                .HasForeignKey(d => d.Pozicija)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_igrac_pozicija");
        });

        modelBuilder.Entity<Izmjena>(entity =>
        {
            entity.HasKey(e => e.IdIzmjena).HasName("PRIMARY");

            entity.ToTable("izmjena");

            entity.HasIndex(e => e.IgracIzlazi, "FK_izmjena_igracIzlazi_idx");

            entity.HasIndex(e => e.IgracUlazi, "FK_izmjena_igracUlazi_idx");

            entity.HasIndex(e => e.Utakmica, "FK_izmjena_utakmica_idx");

            entity.Property(e => e.IdIzmjena).HasColumnName("idIzmjena");
            entity.Property(e => e.IgracIzlazi).HasColumnName("igracIzlazi");
            entity.Property(e => e.IgracUlazi).HasColumnName("igracUlazi");
            entity.Property(e => e.Minut).HasColumnName("minut");
            entity.Property(e => e.Utakmica).HasColumnName("utakmica");

            entity.HasOne(d => d.IgracIzlaziNavigation).WithMany(p => p.IzmjenaIgracIzlaziNavigations)
                .HasForeignKey(d => d.IgracIzlazi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_izmjena_igracIzlazi");

            entity.HasOne(d => d.IgracUlaziNavigation).WithMany(p => p.IzmjenaIgracUlaziNavigations)
                .HasForeignKey(d => d.IgracUlazi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_izmjena_igracUlazi");

            entity.HasOne(d => d.UtakmicaNavigation).WithMany(p => p.Izmjenas)
                .HasForeignKey(d => d.Utakmica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_izmjena_utakmica");
        });

        modelBuilder.Entity<Karton>(entity =>
        {
            entity.HasKey(e => e.IdKarton).HasName("PRIMARY");

            entity.ToTable("karton");

            entity.HasIndex(e => e.Igrac, "FK_karton_igrac_idx");

            entity.HasIndex(e => e.KartonTip, "FK_karton_kartonTip_idx");

            entity.HasIndex(e => e.Utakmica, "FK_karton_utakmica_idx");

            entity.Property(e => e.IdKarton).HasColumnName("idKarton");
            entity.Property(e => e.Igrac).HasColumnName("igrac");
            entity.Property(e => e.KartonTip).HasColumnName("kartonTip");
            entity.Property(e => e.Minut).HasColumnName("minut");
            entity.Property(e => e.Utakmica).HasColumnName("utakmica");

            entity.HasOne(d => d.IgracNavigation).WithMany(p => p.Kartons)
                .HasForeignKey(d => d.Igrac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_karton_igrac");

            entity.HasOne(d => d.KartonTipNavigation).WithMany(p => p.Kartons)
                .HasForeignKey(d => d.KartonTip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_karton_kartonTip");

            entity.HasOne(d => d.UtakmicaNavigation).WithMany(p => p.Kartons)
                .HasForeignKey(d => d.Utakmica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_karton_utakmica");
        });

        modelBuilder.Entity<KartonTip>(entity =>
        {
            entity.HasKey(e => e.IdKartonTip).HasName("PRIMARY");

            entity.ToTable("karton_tip");

            entity.Property(e => e.IdKartonTip).HasColumnName("idKartonTip");
            entity.Property(e => e.Tip)
                .HasMaxLength(45)
                .HasColumnName("tip");
        });

        modelBuilder.Entity<Klub>(entity =>
        {
            entity.HasKey(e => e.IdKlub).HasName("PRIMARY");

            entity.ToTable("klub");

            entity.Property(e => e.IdKlub).HasColumnName("idKlub");
            entity.Property(e => e.Grad)
                .HasMaxLength(100)
                .HasColumnName("grad");
            entity.Property(e => e.NazivKluba)
                .HasMaxLength(100)
                .HasColumnName("nazivKluba");
            entity.Property(e => e.Slika)
                .HasMaxLength(255)
                .HasColumnName("slika");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.IdKorisnik).HasName("PRIMARY");

            entity.ToTable("korisnik");

            entity.HasIndex(e => e.Role, "FK_korisnik_role_idx");

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.Property(e => e.IdKorisnik).HasColumnName("idKorisnik");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .HasColumnName("ime");
            entity.Property(e => e.Lozinka)
                .HasMaxLength(255)
                .HasColumnName("lozinka");
            entity.Property(e => e.Prezime)
                .HasMaxLength(50)
                .HasColumnName("prezime");
            entity.Property(e => e.Role).HasColumnName("role");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_korisnik_role");
        });

        modelBuilder.Entity<Pozicija>(entity =>
        {
            entity.HasKey(e => e.OznakaPozicije).HasName("PRIMARY");

            entity.ToTable("pozicija");

            entity.Property(e => e.OznakaPozicije)
                .HasMaxLength(5)
                .HasColumnName("oznakaPozicije");
            entity.Property(e => e.NazivPozicije)
                .HasMaxLength(45)
                .HasColumnName("nazivPozicije");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("role");

            entity.HasIndex(e => e.NazivRole, "naziv_role_UNIQUE").IsUnique();

            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.NazivRole)
                .HasMaxLength(50)
                .HasColumnName("nazivRole");
        });

        modelBuilder.Entity<Stadion>(entity =>
        {
            entity.HasKey(e => e.IdStadion).HasName("PRIMARY");

            entity.ToTable("stadion");

            entity.Property(e => e.IdStadion).HasColumnName("idStadion");
            entity.Property(e => e.Grad)
                .HasMaxLength(100)
                .HasColumnName("grad");
            entity.Property(e => e.Kapacitet).HasColumnName("kapacitet");
            entity.Property(e => e.Naziv)
                .HasMaxLength(100)
                .HasColumnName("naziv");
            entity.Property(e => e.Podloga)
                .HasMaxLength(100)
                .HasColumnName("podloga");
        });

        modelBuilder.Entity<Utakmica>(entity =>
        {
            entity.HasKey(e => e.IdUtakmica).HasName("PRIMARY");

            entity.ToTable("utakmica");

            entity.HasIndex(e => e.Domaci, "FK_utakmica_domaci_idx");

            entity.HasIndex(e => e.Gosti, "FK_utakmica_gosti_idx");

            entity.HasIndex(e => e.Stadion, "FK_utakmica_stadion_idx");

            entity.Property(e => e.IdUtakmica).HasColumnName("idUtakmica");
            entity.Property(e => e.Domaci).HasColumnName("domaci");
            entity.Property(e => e.GoloviDomaci).HasColumnName("goloviDomaci");
            entity.Property(e => e.GoloviGosti).HasColumnName("goloviGosti");
            entity.Property(e => e.Gosti).HasColumnName("gosti");
            entity.Property(e => e.Stadion).HasColumnName("stadion");

            entity.HasOne(d => d.DomaciNavigation).WithMany(p => p.UtakmicaDomaciNavigations)
                .HasForeignKey(d => d.Domaci)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_utakmica_domaci");

            entity.HasOne(d => d.GostiNavigation).WithMany(p => p.UtakmicaGostiNavigations)
                .HasForeignKey(d => d.Gosti)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_utakmica_gosti");

            entity.HasOne(d => d.StadionNavigation).WithMany(p => p.Utakmicas)
                .HasForeignKey(d => d.Stadion)
                .HasConstraintName("FK_utakmica_stadion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
