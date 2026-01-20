using Application.Shared;
using Application.TournamentService;
using Domain.Tournament;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddTransient<TournamentService>();
builder.Services.AddTransient<ITournamentRepository, TournRepoMock>();
builder.Services.AddTransient<IUnitOfWork, UoWMock>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();

class TournRepoMock : ITournamentRepository
{
    public async Task AddAsync(Tournament tournament)
    {
        Console.WriteLine("AddAsync called.");
        await Task.CompletedTask;
    }

    public Task<Tournament?> GetByIdAsync(TournamentId tournamentId)
    {
        Console.WriteLine("GetByIdAsync called.");
        return Task.FromResult<Tournament?>(null);
    }

    public async Task RemoveAsync(TournamentId tournamentId)
    {
        Console.WriteLine("RemoveAsync called.");
        await Task.CompletedTask;
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