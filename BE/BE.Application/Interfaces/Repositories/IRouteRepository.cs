using BE.Application.Features.Routes.Query.GetAllRoute;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Interfaces.Repositories;

public interface IRouteRepository
{
	Task<Route> GetRouteById(int id);
	Task<List<GetAllRouteDto>> GetAll();
}
