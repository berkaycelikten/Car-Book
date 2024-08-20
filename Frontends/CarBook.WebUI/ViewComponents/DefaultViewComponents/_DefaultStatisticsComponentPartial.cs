using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{

    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region İstatistikGetCarLocation
            var responseMessage = await client.GetAsync("https://localhost:7265/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticksDto>(jsonData);
                ViewBag.carCount = values.carCount;
            }
            #endregion

            #region GetLocation
            var responseMessage2 = await client.GetAsync("https://localhost:7265/api/Statistics/GetLocationCount\r\n");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticksDto>(jsonData2);
                ViewBag.locationCount = values2.locationCount;
            }
            #endregion
            

            #region brandCount

            var responseMessage3 = await client.GetAsync("https://localhost:7265/api/Statistics/GetBrandCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3= JsonConvert.DeserializeObject<ResultStatisticksDto>(jsonData3);
                ViewBag.brandCount = values3.brandCount;
            }
            #endregion

            #region elektrikli_arac
            var responseMessage4 = await client.GetAsync("https://localhost:7265/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticksDto>(jsonData4);
                ViewBag.carCountByFuelElectric = values4.carCountByFuelElectric;
            }
            #endregion
            return View();
        }
    }
}
