using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Domain.Entitiyes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
	public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACaarQueryResult>>
	{
		private readonly IRentACarRepository _repository;

		public GetRentACarQueryHandler(IRentACarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACaarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values =await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Avaible == true);
			var results = values.Select(y => new GetRentACaarQueryResult
			{
				CarId = y.CarID,
				Brand = y.Car.Brand.Name,
				Model=y.Car.Model,
			}).ToList();
			return results;
		}
	}
}
