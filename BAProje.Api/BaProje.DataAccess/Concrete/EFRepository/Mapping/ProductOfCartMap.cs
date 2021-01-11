using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.DataAccess.Concrete.EFRepository.Mapping
{
    public class ProductOfCartMap : IEntityTypeConfiguration<ProductOfCart>
    {
        

        public void Configure(EntityTypeBuilder<ProductOfCart> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne(I => I.Cart).WithMany(I => I.ProductOfCart).HasForeignKey(I => I.CartId);
        }
    }
}
