using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.DataAccess.Concrete.EFRepository.Mapping
{
    public class ProductBlogMap : IEntityTypeConfiguration<ProductBlog>
    {
        public void Configure(EntityTypeBuilder<ProductBlog> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.ProductName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.StockQuantity).IsRequired();
            builder.Property(I => I.ProductDescription).HasMaxLength(3000);
            builder.Property(I => I.Price).IsRequired();

            builder.HasMany(I => I.Comments).WithOne(I => I.ProductBlog).HasForeignKey(I => I.PruductBlogId);

        }
    }
}
