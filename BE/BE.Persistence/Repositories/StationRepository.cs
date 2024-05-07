using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Repositories;

public class StationRepository : IStationRepository
{
	private readonly IGenericRepository<Station> _repository;

	public StationRepository(IGenericRepository<Station> repository)
	{
		_repository = repository;
	}

	public async Task<Station> GetStationById(int id)
	{
		return await _repository.Entities.Where(x => x.Id == id).SingleOrDefaultAsync();
	}
}
