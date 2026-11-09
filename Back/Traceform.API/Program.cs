using Traceform.API.Middleware;
using Traceform.Application;
using Traceform.Infrastructure;
using Traceform.Infrastructure.Persistence;
using Traceform.Infrastructure.Persistence.Context;
using Traceform.Infrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TraceformDbContext>();
    await TraceformDbSeeder.SeedAsync(dbContext);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
