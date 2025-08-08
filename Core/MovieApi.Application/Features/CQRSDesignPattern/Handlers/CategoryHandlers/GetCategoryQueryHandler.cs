using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
       private readonly MovieContext _context;

        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetCategoryQueryResults>> Handle() 
        {
            var values = await _context.Categories.ToListAsync();
            return values.Select(x => new GetCategoryQueryResults
            { 
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToList();        
        }
    }
}
