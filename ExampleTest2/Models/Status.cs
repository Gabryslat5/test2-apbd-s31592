using System.ComponentModel.DataAnnotations;

namespace ExampleTest2.Models;

public class Status
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Nam { get; set; }
}