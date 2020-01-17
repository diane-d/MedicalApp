using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalApp.EntityFramework
{
    public class MedicalContext : DbContext
    { 
        private const string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Medical;Integrated Security=true;";

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Examination> Examinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Physician>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Examination>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
 }
    