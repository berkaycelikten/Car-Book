using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entitiyes;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRespository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingsWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 2).ToList();
			return values;
		}

		public List<CarPricing> GetCarPricingsWithTimePeriod()
		{
			throw new NotImplementedException();
		}

		public List<CarPricingViewModel> GetCarPricingsWithTimePeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = @"
            Select * From 
            (
                Select Model, Name, CoverImageUrl, PricingID, Amount 
                From CarPricings 
                Inner Join Cars On Cars.CarID = CarPricings.CarId 
                Inner Join Brands On Brands.BrandID = Cars.BrandID
            ) As SourceTable 
            Pivot 
            (
                Sum(Amount) 
                For PricingID In ([2], [3], [4])
            ) as PivotTable;";

				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand = reader["Name"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
					{
						reader["2"] != DBNull.Value ? Convert.ToDecimal(reader["2"]) : 0,
						reader["3"] != DBNull.Value ? Convert.ToDecimal(reader["3"]) : 0,
						reader["4"] != DBNull.Value ? Convert.ToDecimal(reader["4"]) : 0
					}
						};
						values.Add(carPricingViewModel);
					}
				}

				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}
