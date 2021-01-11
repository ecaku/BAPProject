using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.DataAccess.Concrete.EFRepository.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.CategoryName).HasMaxLength(100).IsRequired();
            builder.HasIndex(I => I.CategoryName).IsUnique(true);

            builder.HasMany(I => I.Products).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);
        }
    }
}
