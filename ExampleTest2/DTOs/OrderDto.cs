namespace ExampleTest2.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime AcceptedAt { get; set; }
    public DateTime FulfilledAt { get; set; }
    public string Comments { get; set; }
    public List<PastryDto> Pastries { get; set; }
}