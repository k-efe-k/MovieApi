using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _context;

        public RemoveCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var values = _context.Casts.FindAsync(request.CastID);
            _context.Casts.Remove(await values);
            await _context.SaveChangesAsync();
        }
    }
}
