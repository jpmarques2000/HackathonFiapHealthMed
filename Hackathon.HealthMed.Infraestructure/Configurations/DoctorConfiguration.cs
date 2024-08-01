using Hackathon.HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Infraestructure.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder.Property(e => e.Id).UseIdentityColumn().IsRequired();
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.CPF)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(e => e.CRM)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(e => e.Password)
               .IsRequired()
               .HasMaxLength(100);
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.ProfileId).IsRequired();
            builder.Property(e => e.Enabled).IsRequired().HasDefaultValueSql("(1)");
            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.LastModifiedDate);
        }
    }
}
