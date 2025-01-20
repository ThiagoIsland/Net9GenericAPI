using GenericAPI;
using GenericAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GenericAPI.Application;
using OpenTelemetry.Metrics;
using OpenTelemetry.Exporter.Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration);

builder.WebHost.UseUrls("http://localhost:5155");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenTelemetry()
    .WithMetrics(metrics =>
    {
        metrics.AddPrometheusExporter();
        
        metrics.AddAspNetCoreInstrumentation();
        metrics.AddMeter("Microsoft.Extension.Hosting", "Microsoft.AspNetCore.Server.Kestrel");
        metrics.AddView("Http.Server.Request.duration", new ExplicitBucketHistogramConfiguration
        {
            Boundaries = new double[] { 0, 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 }
        });
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GenericAPI v1"));
}

app.UseRouting();
//app.MapMetrics();
app.MapPrometheusScrapingEndpoint();
app.UseAuthorization();  
app.MapControllers();

app.Run();