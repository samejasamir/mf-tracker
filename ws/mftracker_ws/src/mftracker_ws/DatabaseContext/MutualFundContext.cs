using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using mftracker_ws.Model;
using MySQL.Data.Entity.Extensions;

namespace mftracker_ws.DatabaseContext
{
    public class MutualFundContext : DbContext
    {
        private readonly string ConnectionString;

        public MutualFundContext(ConfigManager.Config config)
        {
            ConnectionString = config.ConnectionString;
        }

        public DbSet<Amc> Amcs { get; set; }

        public DbSet<Scheme> Schemes { get; set; }

        public DbSet<Nav> Navs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Amc>().ToTable("amc");
            modelBuilder.Entity<Amc>().Property(p => p.AmcID).HasColumnName("amc_id");
            modelBuilder.Entity<Amc>().Property(p => p.AmcName).HasColumnName("amc_name");

            modelBuilder.Entity<Scheme>().ToTable("mutualfunds");
            modelBuilder.Entity<Scheme>().Property(p => p.SchemeID).HasColumnName("mf_id");
            modelBuilder.Entity<Scheme>().Property(p => p.AmcID).HasColumnName("amc_id");
            modelBuilder.Entity<Scheme>().Property(p => p.SchemeName).HasColumnName("mf_scheme_name");
            modelBuilder.Entity<Scheme>().Property(p => p.SchemeISIN).HasColumnName("mf_isin");
            modelBuilder.Entity<Scheme>().Property(p => p.SchemeCode).HasColumnName("mf_scheme_code");
            modelBuilder.Entity<Scheme>().Property(p => p.SchemeType).HasColumnName("mf_scheme_type");            
            //modelBuilder.Entity<Scheme>().HasOne(p => p.Amc).WithMany(b => b.Schemes).HasForeignKey(p => p.AmcID);

            modelBuilder.Entity<Nav>().ToTable("nav");
            modelBuilder.Entity<Nav>().Property(p => p.NavID).HasColumnName("nav_id");
            modelBuilder.Entity<Nav>().Property(p => p.SchemeID).HasColumnName("mf_id");
            modelBuilder.Entity<Nav>().Property(p => p.NavDate).HasColumnName("nav_date");
            modelBuilder.Entity<Nav>().Property(p => p.NavValue).HasColumnName("nav");
            modelBuilder.Entity<Nav>().Property(p => p.NavRepurchase).HasColumnName("nav_repurchase");
            modelBuilder.Entity<Nav>().Property(p => p.NavSale).HasColumnName("nav_sales_price");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(ConnectionString);
        }

    }
}

