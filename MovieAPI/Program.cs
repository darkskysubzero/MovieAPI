using Microsoft.EntityFrameworkCore;
using Movie.API.DBContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieContext>(options=>{
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello Wor");

app.Run();
