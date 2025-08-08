using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries.MovieQueries
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateMovieCommands command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            if (value != null)
            {
                value.Rating = command.Rating;
                value.Status = command.Status;
                value.Duration = command.Duration;
                value.Title = command.Title;
                value.CoverImageUrl = command.CoverImageUrl;

                await _context.SaveChangesAsync(); // Değişiklikleri veritabanına kaydetmeyi unutma
            }
        }
    }
}
