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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");
            builder.Property(e => e.Id).UseIdentityColumn().IsRequired();
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(e => e.CPF)
                .IsRequired()
                .HasMaxLength(14);
            builder.Property(e => e.ProfileId).IsRequired();
            builder.Property(e => e.Enabled)
                .IsRequired()
                .HasDefaultValueSql("(1)");
            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.LastModifiedDate);
        }
    }
}
