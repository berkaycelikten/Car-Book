﻿using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entitiyes;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            var values=_context.Cars.Count();
            return values;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values=_context.Cars.Include(x=>x.Brand).ToList();
            return values;
                
        }
        public List<Car> GetLast5CarWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();
            return values;
        }
    }
    
}
