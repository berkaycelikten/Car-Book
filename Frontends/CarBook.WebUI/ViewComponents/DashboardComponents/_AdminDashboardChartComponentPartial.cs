using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChartComponentPartial:ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}