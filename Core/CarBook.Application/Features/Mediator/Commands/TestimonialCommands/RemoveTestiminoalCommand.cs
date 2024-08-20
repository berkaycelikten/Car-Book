using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestiminoalCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveTestiminoalCommand(int id)
        {
            Id = id;
        }
    }
}
