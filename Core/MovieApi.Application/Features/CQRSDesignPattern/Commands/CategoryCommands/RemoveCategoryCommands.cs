using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands
{
    public class RemoveCategoryCommands
    {
        public RemoveCategoryCommands(int categoryId)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
    }
}
