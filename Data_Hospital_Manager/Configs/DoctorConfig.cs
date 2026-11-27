using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager.Configs
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.LastName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Specialty).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Email).IsRequired().HasMaxLength(100);
            builder.Property(d => d.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.HasMany(d => d.DoctorPatients)
                .WithOne(dp => dp.Doctor)
                .HasForeignKey(dp => dp.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Hospital)
                .WithMany(h => h.Doctors)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
