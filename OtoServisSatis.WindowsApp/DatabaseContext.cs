using OtoServisSatis.Entities;
using System;
using System.Data.Entity;

namespace OtoServisSatis.WindowsApp
{
    public class DatabaseContext : DbContext
    {
        // Constructor: App.config'deki connection string'i kullanır
        public DatabaseContext() : base("name=DatabaseContext")
        {
        }

        // Tablolara karşılık gelen DbSet tanımları
        public DbSet<Arac> Arac { get; set; }
        public DbSet<Marka> Marka { get; set; }

        // Diğer tablolar için DbSet tanımları ekleyin
        // public DbSet<Servis> Servis { get; set; }
        // public DbSet<Satis> Satis { get; set; }
    }
}