using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

public class Order
{
    [Key]
    public int ID { get; set; }
    public DateTime AcceptedAt { get; set; }
    public DateTime FulfilledAt { get; set; }
    public string Comments { get; set; }
    public int ClientID { get; set; }
    [ForeignKey(nameof(ClientID))]
    public Client Client { get; set; }
    public int EmployeeID { get; set; }
    [ForeignKey(nameof(EmployeeID))]
    public Employee Employee { get; set; }
    public List<OrderPastry> OrderPastries { get; set; }
}