using System;

namespace Movie.API.DTO;

public class DirectorDTO
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public int MovieId { get; set;}

}
