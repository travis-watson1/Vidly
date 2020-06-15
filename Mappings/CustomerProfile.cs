using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
