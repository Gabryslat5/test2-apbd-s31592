namespace ExampleTest2.DTOs;

public class OrderRequest
{
    public int EmployeeId { get; set; }
    public DateTime AcceptedAt { get; set; }
    public string Comments { get; set; }
    public List<OrderPastriesRequest> Pastries { get; set; }
}