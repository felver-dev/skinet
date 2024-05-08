using back.Extensions;
using back.Infrastructure.context;
using back.Infrastructure.Data;
using back.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.ApplicationServices(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

StoreInitializer.Seed(app);
app.Run();
