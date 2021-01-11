using AutoMapper;
using BAProje.Entities.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaProje.WebApi.Mapper.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CustomerLoginDto, Customer>();
            CreateMap<Customer, CustomerLoginDto>();

            CreateMap<ProductListDto, Product>();
            CreateMap<Product, ProductListDto>();

            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();

            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();

            CreateMap<Customer, CustomerRegisterDto>();
            CreateMap<CustomerRegisterDto, Customer>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

        }
    }
}
