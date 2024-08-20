using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class UpdateTestimonialCommand:IRequest
    {
        public int TEstimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Commend { get; set; }
        public string ImageUrl { get; set; }
    }
}
