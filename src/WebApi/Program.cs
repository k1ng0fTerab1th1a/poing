using Application.Shared;
using Application.TournamentService;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Tournaments;
using Microsoft.EntityFrameworkCore;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

string conString = builder.Configuration.GetConnectionString("Default") 
    ?? throw new InvalidOperationException("Could not access default database connection string.");

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<PoingDbContext>(options =>
{
    options.UseMySql(conString, ServerVersion.AutoDetect(conString));
});

builder.Services.AddTransient<TournamentService>();
builder.Services.AddTransient<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<PoingDbContext>());

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
        options.RoutePrefix = "";
    });

    using (IServiceScope scope = app.Services.CreateScope())
    {
        try
        {
            PoingDbContext dbContext = scope.ServiceProvider.GetRequiredService<PoingDbContext>();
            dbContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Migration failed: {ex.Message}");
            throw;
        }
    }
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
