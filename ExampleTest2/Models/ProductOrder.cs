using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Product_Order")]
[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public class ProductOrder
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
    
    [ForeignKey(nameof(OrderId))]
    public Order2 Order { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
}