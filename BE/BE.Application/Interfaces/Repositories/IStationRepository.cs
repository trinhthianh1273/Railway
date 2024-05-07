using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Interfaces.Repositories;

public interface IStationRepository
{
	Task<Station> GetStationById(int id);
}
