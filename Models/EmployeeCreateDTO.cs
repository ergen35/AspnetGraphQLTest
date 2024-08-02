using System.ComponentModel.DataAnnotations;

namespace AspnetGraphQL.Models;

public class EmployeeCreateDTO
{
    [Required, StringLength(maximumLength: 128, MinimumLength = 3)]
    public string Name { get; set; }

    [Range(15, 258), Required]
    public int Age { get; set; }
    
    [Required, Range(1, 1000)]
    public int DeptId { get; set; }
}