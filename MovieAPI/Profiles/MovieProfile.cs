using System;
using AutoMapper;
using Movie.API.DTO;
using Movie.API.Entities;

namespace Movie.API.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile(){
        CreateMap<MovieInfo, MovieDTO>().ReverseMap();
       
       CreateMap<Director, DirectorDTO>()
        .ForMember(x => x.MovieId, o => o.MapFrom(d => d.Movies.First().Id ));

    }

}
