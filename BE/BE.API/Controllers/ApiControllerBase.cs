using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public abstract class ApiControllerBase : ControllerBase
	{
	}
}
