namespace AspnetGraphQL.Models;

public class Employee
{
    public Employee()
    {
        
    }
    public Employee(int id, string name, int age, int deptId)
    {
        Id = id; Age = age; Name = name; DeptId = deptId;
    }
    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public int DeptId { get; set; }
}

public class Department
{
    public Department(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}
