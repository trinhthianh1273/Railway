using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Trains.Query.GetAllTrain;

public class GetAllTrainDto
{
	public int Id { get; set; }
	public string TrainName { get; set; }
	public int CoachCount { get; set; }
	public int SeatCount { get; set; }
	public int TripCount { get; set; }
	public List<Trip> Trips { get; set; }

}
