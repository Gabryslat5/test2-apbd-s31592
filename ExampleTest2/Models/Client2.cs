using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Client2
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public List<Order2> Orders { get; set; }
}