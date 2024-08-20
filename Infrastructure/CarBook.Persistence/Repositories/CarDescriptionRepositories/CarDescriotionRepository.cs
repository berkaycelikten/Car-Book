using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entitiyes;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
	public class CarDescriotionRepository : ICarDescriptionRepository
	{
		private readonly CarBookContext _context;

		public CarDescriotionRepository(CarBookContext context)
		{
			_context = context;
		}



		async Task<CarDescription> ICarDescriptionRepository.GetCarDescription(int carId)
		{
			var values =await _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
			return values;
		}
	}
}
