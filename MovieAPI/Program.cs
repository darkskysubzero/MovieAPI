using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.API.DBContexts;
using Movie.API.DTO;
using Movie.API.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieContext>(options=>{
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
 

app.MapGet("/",()=> "Empty!");

// Get all movies
app.MapGet("/movies", async (MovieContext context, IMapper mapper)=> {
    var results = await context.Movies.ToListAsync();
    return mapper.Map<IEnumerable<MovieDTO>>(results);
});
 

// Get movie using ID
app.MapGet("/movies/{id:int}", async (MovieContext context, IMapper mapper, int id)=>{
    var result = await context.Movies.FirstOrDefaultAsync(x=>x.Id == id);
    return mapper.Map<MovieDTO>(result);
});


// Get all movies with title
app.MapGet("/movies/{title}", async Task<Results<NoContent, Ok<ICollection<MovieDTO>>>>(MovieContext context, string? title, IMapper mapper) => {
    var result = await context.Movies.Where(x=>title==null || x.Title.ToLower().Contains(title.ToLower())).ToListAsync();
    return (result.Count<=0 || result==null)
    ? TypedResults.NoContent()
    : TypedResults.Ok(mapper.Map<ICollection<MovieDTO>>(result));
});


// Get all directors for a movie
app.MapGet("/movies/{movieId:int}/directors",async (MovieContext context, int movieId, IMapper mapper) => {
    var result =  await context.Movies
                .Include(movie=>movie.Directors)
                .FirstOrDefaultAsync(movie=>movie.Id==movieId);
    
    var directors = result?.Directors;
    
    return mapper.Map<ICollection<DirectorDTO>>(directors);
});

 
 

app.Run(); 
