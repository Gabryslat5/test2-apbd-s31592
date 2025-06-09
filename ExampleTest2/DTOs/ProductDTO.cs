using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.DTOs;

public class ProductDTO
{
    public string Name { get; set; }
    [DataType("decimal")]
    [Precision(10, 2)]
    public decimal Price { get; set; }
    public int Amount { get; set; }
}