using back.Errors;
using back.Infrastructure.context;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
	public class BuggyController : BaseApiController
	{
		private readonly StoreContext context;
		public BuggyController(StoreContext context)
		{
			this.context = context;
		}
		[HttpGet("notfound")]
		public ActionResult GetNotFoundRequest()
		{
			var Thing = context.Products.Find(42);
			if(Thing == null)
			{
				return NotFound(new ApiResponse(404));
			}
			return Ok();
		}
		[HttpGet("servererror")]
		public ActionResult GetServerError()
		{
			var Thing = context.Products.Find(42);
			var thingToReturn = Thing.ToString();
			
			return Ok();
		}
		
		[HttpGet("badrequest")]
		public ActionResult GetBadRequest()
		{
			return BadRequest(new ApiResponse(400));
		}
		
		
		[HttpGet("badrequest/{id}")]
		public ActionResult GetNotFoundRequest(int id)
		{
			return Ok();
		}
	}
}