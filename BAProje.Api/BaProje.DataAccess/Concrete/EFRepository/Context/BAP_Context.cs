using BaProje.DataAccess.Concrete.EFRepository.Mapping;
using BAProje.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.DataAccess.Concrete.EFRepository.Context
{
    public class BAP_Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=BAProjectDB; integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductOfCartMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CartMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductBlogMap());
            


        }
        public DbSet<ProductOfCart> ProductOfCart { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBlog> ProductBlog { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}
