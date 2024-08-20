using CarBook.Application.ViewModels;
using CarBook.Domain.Entitiyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRespository
    {
        List<CarPricing> GetCarPricingsWithCars();
        List<CarPricing> GetCarPricingsWithTimePeriod();
        List<CarPricingViewModel> GetCarPricingsWithTimePeriod1();
    }
}
