using AnimeRecommender.Application.Interfaces;
using AnimeRecommender.Application.Services;
using AnimeRecommender.Infrastructure;
using AnimeRecommender.Infrastructure.External.Jikan;
using AnimeRecommender.Infrastructure.Persistence;
using AnimeRecommender.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<JikanApiClient>();
builder.Services.AddHttpClient<JikanService>();
builder.Services.AddScoped<IAnimeService, JikanApiClient>();

// User
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Favorite
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<FavoriteService>();

// Jikan
builder.Services.AddHttpClient<IJikanService, JikanService>();

builder.Services.AddDbContext<AnimeRecommenderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
