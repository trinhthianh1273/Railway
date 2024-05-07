using BE.Application.Common.Mappings;
using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Stations.Query.GetAllStation;

public class GetAllStationDto : IMapFrom<Station>
{
	public int Id { get; init; }
	public string StationName { get; set; }
}
