using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetallBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetallBlogsWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetAllBlogsWithAuthors();
			return values.Select(x => new GetAllBlogsWithAuthorQueryResult
			{
				AuthorId = x.AuthorId,
				BlogId = x.BlogId,
				CategoryID = x.CategoryID,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				Authorname = x.Author.Name,
				Description = x.Description,
				AuthorDescription = x.Author.Description,
				AuthorImageUrl=x.Author.NameImageURl
			}).ToList();
		}

	}
}
