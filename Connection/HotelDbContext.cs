using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Management_Hotel.Models;

namespace Management_Hotel.Models;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Rapport> Rapports { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Typechambre> Typechambres { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var projectPath = AppDomain.CurrentDomain.BaseDirectory;
            var config = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("HotelDatabase");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Idclient).HasName("client_pkey");

            entity.ToTable("client");

            entity.HasIndex(e => e.Email, "client_email_key").IsUnique();

            entity.Property(e => e.Idclient).HasColumnName("idclient");
            entity.Property(e => e.Adresse).HasColumnName("adresse");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(100)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Idnotification).HasName("notification_pkey");

            entity.ToTable("notification");

            entity.Property(e => e.Idnotification).HasColumnName("idnotification");
            entity.Property(e => e.Dateenvoi).HasColumnName("dateenvoi");
            entity.Property(e => e.Idreservation).HasColumnName("idreservation");
            entity.Property(e => e.Statut)
                .HasMaxLength(20)
                .HasColumnName("statut");
            entity.Property(e => e.Typenotification)
                .HasMaxLength(50)
                .HasColumnName("typenotification");

            entity.HasOne(d => d.IdreservationNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.Idreservation)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("notification_idreservation_fkey");
        });

        modelBuilder.Entity<Paiement>(entity =>
        {
            entity.HasKey(e => e.Idpaiement).HasName("paiement_pkey");

            entity.ToTable("paiement");

            entity.Property(e => e.Idpaiement).HasColumnName("idpaiement");
            entity.Property(e => e.Datepaiement)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datepaiement");
            entity.Property(e => e.Idreservation).HasColumnName("idreservation");
            entity.Property(e => e.Modepaiement)
                .HasMaxLength(50)
                .HasColumnName("modepaiement");
            entity.Property(e => e.Montant)
                .HasPrecision(10, 2)
                .HasColumnName("montant");

            entity.HasOne(d => d.IdreservationNavigation).WithMany(p => p.Paiements)
                .HasForeignKey(d => d.Idreservation)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("paiement_idreservation_fkey");
        });

        modelBuilder.Entity<Rapport>(entity =>
        {
            entity.HasKey(e => e.Idrapport).HasName("rapport_pkey");

            entity.ToTable("rapport");

            entity.Property(e => e.Idrapport).HasColumnName("idrapport");
            entity.Property(e => e.Cheminfichier).HasColumnName("cheminfichier");
            entity.Property(e => e.Idreservation).HasColumnName("idreservation");
            entity.Property(e => e.Typerapport)
                .HasMaxLength(50)
                .HasColumnName("typerapport");

            entity.HasOne(d => d.IdreservationNavigation).WithMany(p => p.Rapports)
                .HasForeignKey(d => d.Idreservation)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("rapport_idreservation_fkey");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Idreservation).HasName("reservation_pkey");

            entity.ToTable("reservation");

            entity.Property(e => e.Idreservation).HasColumnName("idreservation");
            entity.Property(e => e.Datearrivee).HasColumnName("datearrivee");
            entity.Property(e => e.Datedepart).HasColumnName("datedepart");
            entity.Property(e => e.Datereservation).HasColumnName("datereservation");
            entity.Property(e => e.Idclient).HasColumnName("idclient");
            entity.Property(e => e.Idutilisateur).HasColumnName("idutilisateur");
            entity.Property(e => e.Statut)
                .HasMaxLength(20)
                .HasColumnName("statut");

            entity.HasOne(d => d.IdclientNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Idclient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("reservation_idclient_fkey");

            entity.HasOne(d => d.IdutilisateurNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Idutilisateur)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("reservation_idutilisateur_fkey");
        });

        modelBuilder.Entity<Typechambre>(entity =>
        {
            entity.HasKey(e => e.Idtype).HasName("typechambre_pkey");

            entity.ToTable("typechambre");

            entity.Property(e => e.Idtype).HasColumnName("idtype");
            entity.Property(e => e.Capacite).HasColumnName("capacite");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
            entity.Property(e => e.Prixnuit)
                .HasPrecision(10, 2)
                .HasColumnName("prixnuit");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Idutilisateur).HasName("utilisateur_pkey");

            entity.ToTable("utilisateur");

            entity.HasIndex(e => e.Email, "utilisateur_email_key").IsUnique();

            entity.Property(e => e.Idutilisateur).HasColumnName("idutilisateur");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Motdepasse)
                .HasMaxLength(255)
                .HasColumnName("motdepasse");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(100)
                .HasColumnName("prenom");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
