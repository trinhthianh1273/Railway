using AutoMapper;
using BE.Application.Features.Routes.Query.GetAllRoute;
using BE.Application.Features.Routes.Query.GetRouteById;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Mappings.RouteMapping;

public class RouteAutoMapperProfile : Profile
{
	public RouteAutoMapperProfile()
	{
		CreateMap<Route, GetAllRouteDto>()
				.ForMember(dest => dest.DepartureStationName, opt => opt.MapFrom(src => src.DepartureStationNavigation.StationName))
				.ForMember(dest => dest.DestinationStationName, opt => opt.MapFrom(src => src.DestinationStationNavigation.StationName));

		CreateMap<Route, GetRouteByIdDto>()
				.ForMember(dest => dest.DepartureStationName, opt => opt.MapFrom(src => src.DepartureStationNavigation.StationName))
				.ForMember(dest => dest.DestinationStationName, opt => opt.MapFrom(src => src.DestinationStationNavigation.StationName));

	}
}
