using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RemoveCategoryCommandHandler
{
    private readonly MovieContext _context;

    public RemoveCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async     Task
Handle(RemoveCategoryCommands command)
    {
        var value = await _context.Categories.FindAsync(command.CategoryId);
        _context.Categories.Remove(value);
        await _context.SaveChangesAsync();
    }
}
