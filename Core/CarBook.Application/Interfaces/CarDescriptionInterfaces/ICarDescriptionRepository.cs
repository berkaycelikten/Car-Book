﻿using CarBook.Domain.Entitiyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarDescriptionInterfaces
{
	public interface ICarDescriptionRepository
	{
	Task<	CarDescription> GetCarDescription(int carId);
	}
}
