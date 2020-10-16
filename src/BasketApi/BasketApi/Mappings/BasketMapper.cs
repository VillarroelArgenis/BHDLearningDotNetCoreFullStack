using AutoMapper;
using BasketApi.Entities;
using EventBusRabitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApi.Mappings
{
    public class BasketMapper
        : Profile
    {
        public BasketMapper()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
