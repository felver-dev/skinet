using back.Core.Interfaces;
using back.Errors;
using back.Infrastructure.context;
using back.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace back.Extensions
{
	public static class ApplicationServicesExtensions
	{
		public static IServiceCollection ApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.Configure<ApiBehaviorOptions>(options => 
				{
					options.InvalidModelStateResponseFactory = ActionContext =>
					{
						var errors = ActionContext.ModelState
							.Where(x => x.Value.Errors.Count > 0)
							.SelectMany(x => x.Value.Errors)
							.Select(x => x.ErrorMessage)
							.ToArray();
			
							var errorResponse = new ApiValidationErrorResponse
							{
								Errors = errors
							};
			
							return new BadRequestObjectResult(errorResponse);
					};
				});
			return services;
		}
	}
}