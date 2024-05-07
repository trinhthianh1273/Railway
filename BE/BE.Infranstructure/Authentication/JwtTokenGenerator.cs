using BE.Application.Interfaces.Persistences;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace BE.Infranstructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
	private readonly JwtSettings _jwtSettings;
	private readonly IDateTimeProvider _dateTimeProvider;

	public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings, IDateTimeProvider dateTimeProvider)
	{
		_jwtSettings = jwtSettings.Value;
		_dateTimeProvider = dateTimeProvider;
	}

	public string GenerateToken(int id, string FullName)
	{
		var signinCredentials = new SigningCredentials(
				new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
					SecurityAlgorithms.HmacSha256
					);

		var claims = new[]
		{
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, id.ToString()),
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.GivenName, FullName),
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.FamilyName, ""),
				new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, id.ToString()),
		};

		var securityToken = new JwtSecurityToken(
			   issuer: _jwtSettings.Issuer,
			   audience: _jwtSettings.Audience,
			   //expires: _dateTimeProvider.utcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
			   expires: _dateTimeProvider.utcNow.AddMinutes(15),
			   claims: claims,
			   signingCredentials: signinCredentials
			   );

		return new JwtSecurityTokenHandler().WriteToken(securityToken);
	}
}
