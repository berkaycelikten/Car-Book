using CarBook.Application.Interfaces.StatisticsIntefaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var values = _context.Comments.GroupBy(x => x.BlogId).
                              Select(y => new
                              {
                                  BlogID = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogId == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }

        public string GetBrandNameByMaxCar()
        {
            //   var result = _context.Cars
            //.GroupBy(c => c.Brand.Name)
            //.Select(g => new
            //{
            //    BrandName = g.Key, // Marka ismini alıyoruz
            //    ToplamArac = g.Count()
            //})
            //.OrderByDescending(x => x.ToplamArac)
            //.FirstOrDefault();

            //   // Eğer sonuç null ise, varsayılan bir değer döndürülüyor
            //   if (result != null)
            //   {
            //       return result.BrandName; // Marka ismi döndürülüyor
            //   }

            //   return "No Brands Found";


            var values = _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;

        }

        public int GetAuthorCount()
        {
            var value= _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //Select Avg(Amount) from CarPricings where PricingID=(Select PricingID From Pricings Where Name='Günlük')
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }
    

        public int GetBlogCount()
        {
            var value=_context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentpriceDailyMax()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentpriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value=_context.Cars.Where(x=>x.Fuel=="Benzin"||x.Fuel=="Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            var value =_context.Cars.Where(x=>x.Km<=1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value= _context.Locations.Count();
            return value;
        }
    }
}
