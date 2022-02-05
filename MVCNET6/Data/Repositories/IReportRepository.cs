using SigQL.Types;
using SigQL.Types.Attributes;

namespace MVCNET6.Data.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<vwLatestEmployeeStartDates> GetLatestEmployeeStartDates(
            OrderByDirection startDate = OrderByDirection.Ascending);

        IEnumerable<itvfWorkingEmployeesForMonth> GetWorkingEmployeesForMonth(
            [Parameter] int month,
            [Parameter] int year);
    }
}
