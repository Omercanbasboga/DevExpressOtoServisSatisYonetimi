﻿using OtoServisSatis.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace OtoServisSatis.DAL
{
    public class DatabaseContext : DbContext
    {
        
        public DbSet<Arac> Arac { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }

        public DbSet<Servis> Servisler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Musteri ile Satis arasındaki Cascade Delete davranışını kapatıyoruz
            modelBuilder.Entity<Satis>()
                .HasRequired(s => s.Musteri)
                .WithMany() // Eğer Musteri'nin birden fazla Satis ilişkisi varsa
                .HasForeignKey(s => s.MusteriId)
                .WillCascadeOnDelete(false);

            // Arac ile Satis arasındaki Cascade Delete davranışını kapatıyoruz
            modelBuilder.Entity<Satis>()
                .HasRequired(s => s.Arac)
                .WithMany() // Eğer Arac'ın birden fazla Satis ilişkisi varsa
                .HasForeignKey(s => s.AracId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder); // Varsayılan davranışlar için 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
        {
            protected override void Seed(DatabaseContext context)
            {
                if (context.Kullanicilar.Any())
                {
                    context.Kullanicilar.Add(new Kullanici()
                    {
                        Adi = "Admin",
                        AktifMi = true,
                        EklenmeTarihi = DateTime.Now,
                        Email = "admin@otoservissatis.tc",
                        KullaniciAdi = "admin",
                        Sifre = "123456"
                    });
                    context.SaveChanges();  
                }
                base.Seed(context);
            }
            
        }
        public DatabaseContext() : base("name=DatabaseContext") 
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

    }
}
