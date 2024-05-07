using AutoMapper;
using BE.Application.Features.Trains.Query.GetAllTrain;
using BE.Application.Features.Users.Query.GetAllUser;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Common.Mappings.RouteMapping;

public class TrainAutoMapperProfile : Profile
{

	public TrainAutoMapperProfile()
	{
		// ánh xạ Seats từ đối tượng Coach vào GetAllTrainDto
		CreateMap<Coach, GetAllTrainDto>()
			.ForMember(dest => dest.SeatCount, opt => opt.MapFrom(src => src.Seats.Count));


		CreateMap<Train, GetAllTrainDto>()
				.ForMember(dest => dest.CoachCount, opt => opt.MapFrom(src => src.Coaches.Count))
				.ForMember(dest => dest.SeatCount, opt => opt.MapFrom(src => src.Coaches.SelectMany(coach => coach.Seats).Count()));
	}

}
