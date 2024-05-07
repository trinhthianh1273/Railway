using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Interfaces.Persistences;

public interface IJwtTokenGenerator
{
	string GenerateToken(int id, string FullName);
}
