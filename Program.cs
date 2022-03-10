using aninja_anime_service.AsyncDataServices;
using aninja_anime_service.Data;
using aninja_anime_service.Repositories;
using aninja_anime_service.SyncDataServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddGrpc();

builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
builder.Services.AddScoped<IAnimeTagDataClient, AnimeTagDataClient>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DbPrep.PrepData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGrpcService<GrpcAnimeService>();
app.MapGet("/protos/anime.proto", async context =>
{
    await context.Response.WriteAsync(File.ReadAllText("Protos/anime.proto"));
});

app.Run();
