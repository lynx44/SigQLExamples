namespace MVCNET6.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public interface IFields
        {
            int Id { get; }
            string Name { get; }
        }

        public interface IDetails
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public interface IDetailsWithWorkLogs
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public IEnumerable<WorkLog.IFields> WorkLogs { get; set; }
        }
    }
}
