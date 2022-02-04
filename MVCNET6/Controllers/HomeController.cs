using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCNET6.Data;
using MVCNET6.Data.Repositories;
using MVCNET6.Models;

namespace MVCNET6.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkLogRepository _workLogRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(
            IWorkLogRepository workLogRepository,
            IEmployeeRepository employeeRepository)
        {
            _workLogRepository = workLogRepository;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index(int? offset = 0)
        {
            var items = _workLogRepository.GetList(offset);
            ViewBag.PrevOffset = offset.GetValueOrDefault(0) - 10;
            ViewBag.NextOffset = offset.GetValueOrDefault(0) + 10;
            return View(items);
        }

        public IActionResult Add()
        {
            ViewBag.Employees = new SelectList(_employeeRepository.GetSelectListItems(), nameof(Employee.Id), nameof(Employee.Name));
            return View(new WorkLog.Insert());
        }

        [HttpPost]
        public IActionResult Add(WorkLog.Insert model)
        {
            var inserted = _workLogRepository.Insert(model);
            return RedirectToAction(nameof(Details), new {id = inserted.Id});
        }

        public IActionResult Details(int id)
        {
            return View(_workLogRepository.GetDetails(id));
        }

        public IActionResult Delete(int id)
        {
            _workLogRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EmployeeDetail(int id)
        {
            return View(_employeeRepository.GetDetails(id));
        }

        public IActionResult Search()
        {
            ViewBag.Employees = new SelectList(_employeeRepository.GetSelectListItems(), nameof(Employee.Id), nameof(Employee.Name));
            var search = _workLogRepository.Search(new SearchModel());
            return View(search);
        }

        [HttpPost]
        public IActionResult Search(SearchModel model)
        {
            ViewBag.Employees = new SelectList(_employeeRepository.GetSelectListItems(), nameof(Employee.Id), nameof(Employee.Name));
            var results = _workLogRepository.Search(model, model.NumberOfResults);
            return View(results);
        }
    }
}
