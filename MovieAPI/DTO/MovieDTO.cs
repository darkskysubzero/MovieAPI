using System;

namespace Movie.API.DTO;

public class MovieDTO
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }

}
