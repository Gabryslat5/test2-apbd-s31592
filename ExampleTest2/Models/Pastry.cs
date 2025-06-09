using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

public class Pastry
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    [DataType("decimal")]
    [Precision(10, 2)]
    public decimal Price { get; set; }
    [MaxLength(40)]
    public string Type { get; set; }
    public List<OrderPastry> OrderPastries { get; set; }
}