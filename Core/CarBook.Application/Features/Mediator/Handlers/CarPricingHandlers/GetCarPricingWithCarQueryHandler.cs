using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRespository _repository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRespository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingsWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
				Amount = x.Amount,
				CarPricingId = x.CarPricingID,
				Brand = x.Car.Brand.Name,
				CoverImageUrl = x.Car.CoverImageUrl,
				Model = x.Car.Model,
				CarId = x.CarID

			}).ToList();
        }
    }
}
