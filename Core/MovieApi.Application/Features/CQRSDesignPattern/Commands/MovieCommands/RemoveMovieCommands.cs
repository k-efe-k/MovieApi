using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class RemoveMovieCommands
    {
        private int id;

        public RemoveMovieCommands(int id)
        {
            this.id = id;
        }

        public int MovieId { get; set; }

    }
}
