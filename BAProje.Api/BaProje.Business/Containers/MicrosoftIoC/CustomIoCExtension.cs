using BaProje.Business.Concrete;
using BaProje.Business.Interfaces;
using BaProje.Business.Tools.JWTTool;
using BaProje.Business.Tools.JWTTooll.JwtManager;
using BaProje.Business.ValidationRules.FluentValidation;
using BaProje.DataAccess.Concrete.EFRepository.Repositories;
using BaProje.DataAccess.Interfaces;
using DTO;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BaProje.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDal, EfCustomerRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductRepository>();

            services.AddScoped<IProductBlogService, ProductBlogManager>();
            services.AddScoped<IProductBlogDal, EfProductBlogRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartDal, EfCartRepository>();

            services.AddScoped<IProductOfCartService, ProductOfCartManager>();
            services.AddScoped<IProductOfCartDal, EfProductOfCartRepository>();



            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<CustomerLoginDto>, CustomerLoginValidator>();
            services.AddTransient <IValidator<CategoryAddDto>, CategoryAddValidator > ();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            services.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();


            


            

        }
    }
}
