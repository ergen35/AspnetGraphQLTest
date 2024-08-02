using AspnetGraphQL.Models;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using GraphQL.AspNet.Interfaces.Controllers;

namespace AspnetGraphQL.Controllers;

// [GraphRoute("employees")]
public class EmployeesController(IEmployeeService employeeService) : GraphController
{
    [QueryRoot("list", typeof(IEnumerable<Employee>))]
    public IEnumerable<Employee> ListEmployees()
    {
        return employeeService.GetEmployees().AsEnumerable();
    }

    [QueryRoot("employee")]
    public Employee GetEmployee(int id)
    {
        return employeeService.GetEmployee(id);
    }

    [QueryRoot("per_dept")]
    public IEnumerable<Employee> ListEmployeesPerDepartment(int deptId)
    {
        return employeeService.GetEmployeesByDepartment(deptId).AsEnumerable();
    }

    [MutationRoot("addEmploye", typeof(Employee))]
    public IGraphActionResult AddEmployee(EmployeeCreateDTO employee)
    {
        if (!this.ModelState.IsValid)
            return this.BadRequest(ModelState);

        Console.WriteLine("Added " + employee.Name);

        return this.Ok(employeeService.AddEmployee(employee));
    }
}
