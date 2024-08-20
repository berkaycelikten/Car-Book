using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entitiyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCAtegoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCAtegoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CategoryID);
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
