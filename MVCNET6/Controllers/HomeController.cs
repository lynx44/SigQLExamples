using Microsoft.AspNetCore.Mvc;
using MVCNET6.Data.Repositories;

namespace MVCNET6.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkLogRepository _workLogRepository;

        public HomeController(IWorkLogRepository workLogRepository)
        {
            _workLogRepository = workLogRepository;
        }

        public IActionResult Index(int? offset = 0, int? fetch = 10)
        {
            var items = _workLogRepository.GetList(offset, fetch);
            ViewBag.Offset = offset.GetValueOrDefault(0);
            return View(items);
        }
    }
}
