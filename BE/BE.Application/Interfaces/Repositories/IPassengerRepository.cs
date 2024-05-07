using BE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Interfaces.Repositories;

public interface IPassengerRepository
{
	Task<Passenger> Login(string userName, string password);
	Task<bool> CheckEmailExistAsync(string email);
	Task<bool> CheckEmailPhoneNoAsync(string phoneNo);
}
