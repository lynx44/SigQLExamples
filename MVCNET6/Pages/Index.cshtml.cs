using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCNET6.Data;
using MVCNET6.Data.Repositories;

namespace MVCNET6.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWorkLogRepository _workLogRepository;

        public IndexModel(ILogger<IndexModel> logger, IWorkLogRepository workLogRepository)
        {
            _logger = logger;
            _workLogRepository = workLogRepository;
        }

        public void OnGet()
        {
            var items = _workLogRepository.GetList(0, 10);
        }
    }
}