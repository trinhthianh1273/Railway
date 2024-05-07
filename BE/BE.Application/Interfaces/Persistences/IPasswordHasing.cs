using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Interfaces.Persistences;

public interface IPasswordHasing
{
	string HassPassword(string password);
	bool VerifyPassword(string password, string bass64Hash);
}
