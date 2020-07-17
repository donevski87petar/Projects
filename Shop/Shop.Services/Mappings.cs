using AutoMapper;
using Shop.DomainModels.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Services
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductImage, ProductImageViewModel>().ReverseMap();
            CreateMap<AppUser, AppUserViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
