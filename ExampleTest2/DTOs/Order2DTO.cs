namespace ExampleTest2.DTOs;

public class Order2DTO
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime FulfilledAt { get; set; }
    public string Status { get; set; }
    public Client2DTO Client { get; set; }
    public List<ProductDTO> Products { get; set; }
}