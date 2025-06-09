using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

public class Order2
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime FulfilledAt { get; set; }
    public int ClientId { get; set; }
    [ForeignKey(nameof(ClientId))]
    public Client2 Client { get; set; }
    public int StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
    public List<ProductOrder> ProductOrders { get; set; }
}