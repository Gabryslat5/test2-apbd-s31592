using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Client
{
    [Key]
    public int ID { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public List<Order> Orders { get; set; }
}