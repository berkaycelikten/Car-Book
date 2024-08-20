using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Unicode;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDtos createContactDtos)
        {
            var client=_httpClientFactory.CreateClient();
            createContactDtos.SendDate = DateTime.Now;
            var jsondata= JsonConvert.SerializeObject(createContactDtos);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"aplication/json");
            var ResponseMessage = await client.PostAsync("https://localhost:7265/api/Contacts", stringContent);
            if(ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
