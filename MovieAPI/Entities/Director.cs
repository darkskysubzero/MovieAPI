using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Movie.API.Entities;

public class Director
{
    [Key]
    public int Id { get; set;}
    [Required]
    [MaxLength(150)]
    public required string Name { get; set;}
    public ICollection<MovieInfo> Movies { get; set;} = new List<MovieInfo>();
    public Director(){

    }
    
    [SetsRequiredMembers]
    public Director(int id, string name){
        Id = id;
        Name = name;
    }
}
