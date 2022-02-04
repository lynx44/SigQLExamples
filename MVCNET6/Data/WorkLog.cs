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

            Employee.IFields Employee { get; }
        }

        public interface IId
        {
            int Id { get; }
        }

        public interface IDetails
        {
            public int Id { get; set; }
            public DateTime StartDate { get; set; }
            public Employee.IDetails Employee { get; set; }
        }
        
        public interface IFields
        {
            public int Id { get; set; }
            DateTime StartDate { get; }
        }

        public class Insert
        {
            public DateTime StartDate { get; set; }
            public int EmployeeId { get; set; }
        }
    }
}
