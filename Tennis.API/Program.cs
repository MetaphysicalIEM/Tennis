using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Tennis.BLL.IServices;
using Tennis.BLL.Services;
using Tennis.DAL.DataContext;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;

builder.Services.AddDbContext<TennisDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});


builder.Services.AddHealthChecks();
builder.Services.AddScoped<IPlayerService, PlayerService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Tennis API",
        Description = "API WEB related to Tennis"
    });
});

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapHealthChecks("health");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
