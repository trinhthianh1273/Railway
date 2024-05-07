using BE.Application.Features.Routes.Query.GetAllRoute;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Repositories;

public class RouteRepository : IRouteRepository
{
	private readonly IGenericRepository<Route> _repository;

	public RouteRepository(IGenericRepository<Route> repository)
	{
		_repository = repository;
	}

	public Task<List<GetAllRouteDto>> GetAll()
	{
		
		try
		{
			List<GetAllRouteDto> result = new List<GetAllRouteDto>();
			//var route = _repository.Entities
			//				.Include(r => r.DepartureStationNavigation)
			//				.Include(r => r.DestinationStationNavigation);
			//foreach(Route item in route)
			//{
			//	result.Add(
			//		new GetAllRouteDto(
			//			item.Id,
			//			item.RouteName,
			//			item.DepartureStationNavigation.StationName,
			//			item.DestinationStationNavigation.StationName,
			//			item.RouteFare
			//		)
			//	);
			//}
			//return result;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
		throw new NotImplementedException();
	}

	public async Task<Route> GetRouteById(int id)
	{
		return await _repository.Entities.Where(x => x.Id == id).SingleOrDefaultAsync();
	}
}
