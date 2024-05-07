using BE.Application.Interfaces.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Infranstructure.Authentication;

public class DateTimeProvider : IDateTimeProvider
{
	public DateTime utcNow => DateTime.UtcNow;
}
