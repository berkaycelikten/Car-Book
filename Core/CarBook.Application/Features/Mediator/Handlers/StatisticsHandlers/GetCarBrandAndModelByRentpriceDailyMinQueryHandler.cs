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
    public class GetCarBrandAndModelByRentpriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentpriceDailyMinQuery, GetCarBrandAndModelByRentpriceDailyMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentpriceDailyMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByRentpriceDailyMinQueryResult> Handle(GetCarBrandAndModelByRentpriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarBrandAndModelByRentpriceDailyMin();
            return new GetCarBrandAndModelByRentpriceDailyMinQueryResult
            {

                GetCarBrandAndModelByRentpriceDailyMin = values,
            };
        }
    }
}
