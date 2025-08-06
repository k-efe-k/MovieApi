using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handle(CreateMovieCommands commands)
        {
            _context.Movies.Add(new Movie
            {
                CoverImageUrl = commands.CoverImageUrl,
                CreatedYear = commands.CreatedYear,
                Descripton = commands.Description,
                Duration = commands.Duration,
                Rating = commands.Rating,
                ReleaseDate = commands.RelaseDate,
                Status = commands.Status,
                Title = commands.Title
            });
                
            await _context.SaveChangesAsync();
            
        }
    }
}
