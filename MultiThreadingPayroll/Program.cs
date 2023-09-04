using MultiThreading;
using Payroll_Service_ADO_database;

internal class Program
{
    private static void Main(string[] args)
    {
        //UC1

        //EmployeeOperation operations = new EmployeeOperation();
        //List<Employee> list = new List<Employee>();
        //list.Add(new Employee() { Name = "a", City = "a", Address = "a" });
        //list.Add(new Employee() { Name = "b", City = "b", Address = "b" });
        //list.Add(new Employee() { Name = "c", City = "c", Address = "c" });
        //list.Add(new Employee() { Name = "d", City = "d", Address = "d" });
        //list.Add(new Employee() { Name = "e", City = "e", Address = "e" });
        //Operation operation = new Operation();
        //operation.UsingWithoutThread(list);
        //operation.UsingWithThread(list);\

        TaskParllelLibrary task = new TaskParllelLibrary();
        task.TaskParllelOperation();

    }
}

