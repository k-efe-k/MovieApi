using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handle(CreateCategoryCommands command) 
        {
            _context.Categories.add(new Category
            {
                CategoryName = command.CategoryName
            });
            await _context.SaveChangesAsync();
        }
    }
}
