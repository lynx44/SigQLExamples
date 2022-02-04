namespace MVCNET6.Data
{
    public class WorkLog
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public interface IWorkLogListItem
        {
            int Id { get; }
            DateTime StartDate { get; }

            Employee.IEmployeeName Employee { get; }
        }
    }
}
