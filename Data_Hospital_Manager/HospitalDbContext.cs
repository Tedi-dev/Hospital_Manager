using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
<<<<<<< HEAD
        public DbSet<DoctorPatient> DoctorPatients
        {
            get; set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hospital>()
                .HasMany(h => h.Doctors)
                .WithOne(d => d.Hospital)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DoctorPatient>().HasKey(dp => new { dp.DoctorId, dp.PatientId });
=======
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DoctorPatient>()
                .HasKey(dp => new { dp.DoctorId, dp.PatientId });
>>>>>>> 5fd0922e6384c5f943a3eea8c1594797bc7638f8
            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Doctor)
                .WithMany(d => d.DoctorPatients)
                .HasForeignKey(dp => dp.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
<<<<<<< HEAD
            modelBuilder.Entity<DoctorPatient>().HasOne(dp => dp.Patient)
=======
            modelBuilder.Entity<DoctorPatient>()
                .HasOne(dp => dp.Patient)
>>>>>>> 5fd0922e6384c5f943a3eea8c1594797bc7638f8
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(dp => dp.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
