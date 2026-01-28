using Application.Shared;
using Application.TournamentService;
using Domain.Tournament;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Tournaments;
using Microsoft.EntityFrameworkCore;
using WebApi.Middleware;

string conString = "server=localhost;user=EXAMPLE_USER;password=EXAMPLE_PASSWORD;database=poing_dev";
var builder = WebApplication.CreateBuilder(args);

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
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();

class TournRepoMock : ITournamentRepository
{
    public void Add(Tournament tournament)
    {
        Console.WriteLine("AddAsync called.");
        var prop = tournament.GetType().GetProperty(nameof(tournament.Id));
        prop!.SetValue(tournament, new TournamentId(1));
    }

    public Task<Tournament?> GetByIdAsync(TournamentId tournamentId)
    {
        Console.WriteLine("GetByIdAsync called.");
        return Task.FromResult<Tournament?>(null);
    }

    public void Remove(Tournament tournament)
    {
        Console.WriteLine("RemoveAsync called.");
    }
}

class UoWMock : IUnitOfWork
{
    public async Task CommitAsync()
    {
        Console.WriteLine("CommitAsync called.");
        await Task.CompletedTask;
    }
}