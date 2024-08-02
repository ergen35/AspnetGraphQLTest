using AspnetGraphQL.Models;

public interface IEmployeeService
{
    public List<Employee> GetEmployees();

    public Employee GetEmployee(int empId);

    public List<Employee> GetEmployeesByDepartment(int deptId);

    public Employee AddEmployee(EmployeeCreateDTO employee);
}

public class EmployeeService : IEmployeeService
{
    public EmployeeService()
    {

    }
    private List<Employee> employees = new List<Employee>
        {
            new Employee(1, "Tom", 25, 1),
            new Employee(2, "Henry", 28, 1),
            new Employee(3, "Steve", 30, 2),
            new Employee(4, "Ben", 26, 2),
            new Employee(5, "John", 35, 3),

        };

    private List<Department> departments = new List<Department>
        {
            new Department(1, "IT"),
            new Department(2, "Finance"),
            new Department(3, "HR"),
        };

    public List<Employee> GetEmployees()
    {
        return employees.ToList();
    }
    public Employee GetEmployee(int empId)
    {
        return employees.FirstOrDefault(emp => emp.Id == empId);
    }

    public List<Employee> GetEmployeesByDepartment(int deptId)
    {
        return employees.Where(emp => emp.DeptId == deptId)
                .Select(emp => new Employee(emp.Id, emp.Name, emp.Age, deptId))
                .ToList();
    }

    public Employee AddEmployee(EmployeeCreateDTO data)
    {
        var employee = new Employee()
        {
            Id = this.employees.LastOrDefault() is null ? this.employees.Count + 1 : this.employees.LastOrDefault().Id + this.employees.Count - 1,
            Age = data.Age,
            DeptId = data.DeptId,
            Name = data.Name
        };

        this.employees.Add(employee);
        return employee;
    }
}