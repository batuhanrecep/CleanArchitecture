using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Usually, AutoMapper  understand the related properties, if you named the property carefully like BrandName - TransmissionName (TableName+XXX)
        //But if you want to do only name or something else than you need to use the active one and map everything.
        //Also, active one is the best practice
        //CreateMap<Model, GetListModelListItemDto>().ReverseMap();

        //GetList
        CreateMap<Model, GetListModelListItemDto>()
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
            .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
            .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
            .ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();

        //CreateMap<Model, GetListByDynamicModelListItemDto>()
        //    .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
        //    .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
        //    .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
        //    .ReverseMap();
        //CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();



    }
}
