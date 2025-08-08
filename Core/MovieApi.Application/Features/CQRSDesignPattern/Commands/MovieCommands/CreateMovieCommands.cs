﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class CreateMovieCommands
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public Decimal Rating { get; set; }
        public int Duration { get; set; }
        public bool Status { get; set; }

        public bool CreatedYear { get; set; }

        public bool Description { get; set; }

        public bool RelaseDate { get; set; }





    }
}
