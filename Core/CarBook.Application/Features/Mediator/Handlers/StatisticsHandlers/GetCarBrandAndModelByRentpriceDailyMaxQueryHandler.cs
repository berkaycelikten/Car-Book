using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsIntefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarBrandAndModelByRentpriceDailyMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentpriceDailyMaxQuery, GetCarBrandAndModelByRentpriceDailyMaxQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentpriceDailyMaxQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByRentpriceDailyMaxQueryResult> Handle(GetCarBrandAndModelByRentpriceDailyMaxQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarBrandAndModelByRentpriceDailyMax();
            return new GetCarBrandAndModelByRentpriceDailyMaxQueryResult
            {

                CarBrandAndModelByRentpriceDailyMax = values,
            };
        }
    }
}

