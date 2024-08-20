using CarBook.Domain.Entitiyes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarCommand:IRequest
    {
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }

    }
}