using CarBook.Domain.Entitiyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarDescriptionResults
{
	public class GetCarDescrioptionsQueryResult
	{
		public int CarDescriptionID { get; set; }
		public int CarID { get; set; }
		public string Detail { get; set; }
	}
}
