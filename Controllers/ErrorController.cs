using back.Errors;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
	[Route("errors/{code}")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorController : BaseApiController
	{
		[HttpGet]
		public IActionResult Error(int code)
		{
			return new ObjectResult(new ApiResponse(code));
		}
	}
}