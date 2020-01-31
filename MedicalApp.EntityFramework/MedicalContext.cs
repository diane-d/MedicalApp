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
                entity.HasKey(pa => pa.Id);
            });
            modelBuilder.Entity<Physician>(entity =>
            {
                entity.HasKey(ph => ph.Id);
            });
            modelBuilder.Entity<Examination>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Patient).WithMany(pa => pa.Examinations).HasForeignKey(e => e.PatientId);
                entity.HasOne(e => e.Physician).WithMany(ph => ph.Examinations).HasForeignKey(e => e.PhysicianId);
            });
        }
    }
 }