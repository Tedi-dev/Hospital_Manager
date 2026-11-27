using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager.Configs
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasMany(p => p.DoctorPatients)
                .WithOne(dp => dp.Patient)
                .HasForeignKey(dp => dp.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
