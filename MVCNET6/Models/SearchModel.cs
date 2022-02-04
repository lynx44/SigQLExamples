using MVCNET6.Data;

namespace MVCNET6.Models
{
    public class SearchModel : WorkLog.ISearch
    {
        public DateTime? StartRange { get; set; }
        public DateTime? EndRange { get; set; }
        public IEnumerable<int> EmployeeIds { get; set; }
        public int NumberOfResults { get; set; }
    }
}
