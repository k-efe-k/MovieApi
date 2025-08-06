using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries.MovieQueries
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context) { _context = context; }
    }
    public async void Handler   (UpdateMovieCommand command)
    {
        var value = await _context.Movies.FindAsync(command.MovieId);
        value.Rating = command.Rating;
        value.Status = command.Status;
        value.Duration = command.Duration;
        value.MovieId = command.MovieId;
        value.Title = command.Title;
        value.CoverImageUrl = command.CoverImageUrl;
    }
}
