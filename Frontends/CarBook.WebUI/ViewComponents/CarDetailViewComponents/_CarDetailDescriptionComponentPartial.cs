using CarBook.Dto.CarDescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailDescriptionComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;
			var client = _httpClientFactory.CreateClient();
			var resposenMessage = await client.GetAsync($"https://localhost:7265/api/CarDescriptions?id="+id);
			if (resposenMessage.IsSuccessStatusCode)
			{
				var jsonData = await resposenMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCarDescriptionByCarIdDto>(jsonData);
				return View(values);
			}
			return View();
		}

	}
}
