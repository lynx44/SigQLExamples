namespace MVCNET6.Data.Repositories
{
    public interface IEmployeeRepository
    {
        Employee.IDetailsWithWorkLogs GetDetails(int id);
        IEnumerable<Employee.IFields> GetSelectListItems();
    }
}
