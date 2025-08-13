using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetMovieQueryResult>> Handle() 
        {
            var values = await _context.Movies.ToListAsync();
            return values.Select(x=> new GetMovieQueryResult
            {
                MovieId = x.MovieId,
                CoverImageUrl = x.CoverImageUrl,
                Duration=x.Duration,
                Rating=x.Rating,
                Status=x.Status,
                Title=x.Title,
            }).ToList();
        }

        public async Task Handler()
        {
            throw new NotImplementedException();
        }
    }
}
