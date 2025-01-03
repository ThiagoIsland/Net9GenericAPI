using GenericAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GenericAPI.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGenericService, GenericService>();

builder.Services.AddDbContext<BaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.WebHost.UseUrls("http://localhost:5155");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GenericAPI v1"));
}

//app.UseStaticFiles();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();