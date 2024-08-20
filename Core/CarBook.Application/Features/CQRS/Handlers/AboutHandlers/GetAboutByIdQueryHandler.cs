using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entitiyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {

            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {

                AboutID = values.AboutID,
                Descriptons = values.Descriptons,
                Title = values.Title,
                İmageUrl = values.İmageUrl
            };

        }

        public Task Handle()
        {
            throw new NotImplementedException();
        }
    }
}
