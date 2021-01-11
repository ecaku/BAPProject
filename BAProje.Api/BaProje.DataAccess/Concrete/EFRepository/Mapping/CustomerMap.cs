using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BaProje.DataAccess.Concrete.EFRepository.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.CustomerName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(100);

            
            builder.HasIndex(I => I.Email).IsUnique(true);
            builder.HasIndex(I => I.CustomerName).IsUnique(true);
            

            builder.HasOne(I => I.Cart).WithOne(I => I.Customer).HasForeignKey<Cart>(I => I.CustomerId);
        }
    }
}
