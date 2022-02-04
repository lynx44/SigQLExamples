namespace MVCNET6.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public interface IEmployeeName
        {
            string Name { get; }
        }
    }
}
