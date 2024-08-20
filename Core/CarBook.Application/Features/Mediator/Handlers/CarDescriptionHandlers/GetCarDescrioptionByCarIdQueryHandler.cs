using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entitiyes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class GetCarDescrioptionByCarIdQueryHandler : IRequestHandler<GetCarDescrioptionsByCarIdQuery, GetCarDescrioptionsQueryResult>
	{
		private readonly ICarDescriptionRepository _repository;

		public GetCarDescrioptionByCarIdQueryHandler(ICarDescriptionRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDescrioptionsQueryResult> Handle(GetCarDescrioptionsByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values =await  _repository.GetCarDescription(request.Id);
			return new GetCarDescrioptionsQueryResult
			{
				CarDescriptionID = values.CarDescriptionID,
				CarID = values.CarID,
				Detail= values.Detail,
			};
		}
	}
}

