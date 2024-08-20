using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
    public class CreateAboutCommands
    {
        public string Title { get; set; }
        public string Descriptons { get; set; }
        public string İmageUrl { get; set; }
    }
}
