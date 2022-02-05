using Microsoft.AspNetCore.Mvc;
using MVCNET6.Data;
using MVCNET6.Data.Repositories;
using SigQL.Types;

namespace MVCNET6.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportRepository _reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LatestEmployeeStartDates(OrderByDirection sortDirection = OrderByDirection.Ascending)
        {
            var results = _reportRepository.GetLatestEmployeeStartDates(sortDirection);
            return View(results);
        }

        public IActionResult WorkingEmployeesForMonth(int? month = null, int? year = null)
        {
            var results = _reportRepository.GetWorkingEmployeesForMonth(month ?? DateTime.Today.Month, year ?? DateTime.Today.Year);
            return View(results);
        }
    }
}
