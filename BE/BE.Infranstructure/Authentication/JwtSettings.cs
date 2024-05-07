using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Infranstructure.Authentication;

public class JwtSettings
{
	public const string SectionName = "JwtSettings";
	public string Secret { get; init; } = "super-secret-keysuper-secret-key";
	public int ExpiryMinutes { get; init; } = 60;
	public string Issuer { get; init; } = "RailwayReservation";
	public string Audience { get; init; } = "RailwayReservation";

}
