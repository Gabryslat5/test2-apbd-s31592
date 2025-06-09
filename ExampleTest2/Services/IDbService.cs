using ExampleTest2.DTOs;
using ExampleTest2.Models;

namespace ExampleTest2.Services;

public interface IDbService
{
    Task<List<OrderDto>> GetClientOrdersAsync(string clientLastName);
    Task<bool> AddNewOrderAsync(int clientId, OrderRequest request);
    
    Task<Order2DTO> GetOrderAsync(int orderId);
    Task UpdateOrderAsync(int orderId, Order2Request request);
}