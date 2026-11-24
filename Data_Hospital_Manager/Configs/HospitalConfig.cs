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
    public class HospitalConfig : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasData(
                new Hospital {
                    Id = 1,
                    Name = "City Hospital",
                    Address = "123 Main St, Cityville",
                    Email = "hos@pital.con",
                    PhoneNumber = "123-456-7890",
                    BedsCount = 100,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false
                },
                new Hospital {
                    Id = 2,
                    Name = "County General",
                    Address = "456 Elm St, Countyville",
                    Email = "hos@pital.com",
                    PhoneNumber = "987-654-3210",
                    BedsCount = 200,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}
