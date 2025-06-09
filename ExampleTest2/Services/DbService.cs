using System.Transactions;
using ExampleTest2.Data;
using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using ExampleTest2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<OrderDto>> GetClientOrdersAsync(string clientLastName)
    {
        var clientsOrders = await _context.Orders
            .Where(o => clientLastName == null || o.Client.LastName == clientLastName)
            .Select(o => new OrderDto
            {
                Id = o.ID,
                AcceptedAt = o.AcceptedAt,
                FulfilledAt = o.FulfilledAt,
                Comments = o.Comments,
                Pastries = o.OrderPastries.Select(o => new PastryDto()
                {
                    name = o.Pastry.Name,
                    price = o.Pastry.Price,
                    amount = o.Amount
                }).ToList()
            }).ToListAsync();
        
        if (!clientsOrders.Any())
            throw new NotFoundException("Order not found.");
        
        return clientsOrders;
    }

    public async Task<bool> AddNewOrderAsync(int clientId, [FromBody] OrderRequest request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.ID == clientId);
            if (client is null)
                throw new NotFoundException("Client not found.");
            
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.ID == request.EmployeeId);
            if (employee is null)
                throw new NotFoundException("Employee not found.");

            var order = new Order()
            {
                AcceptedAt = request.AcceptedAt,
                Comments = request.Comments,
                EmployeeID = request.EmployeeId,
                ClientID = clientId
            };
            
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            
            var pastries = new List<OrderPastry>();
            Console.WriteLine("Jestem tutaj!!!");
            Console.WriteLine(request.Pastries.Count);
            foreach (var newPastry in request.Pastries)
            { 
                Console.WriteLine("Hej");
                var pastry = await _context.Pastries.FirstOrDefaultAsync(p => p.Name == newPastry.Name);
                
                if (pastry is null)
                    throw new NotFoundException("Pastry not found.");
                
                Console.WriteLine("Nazwa: " + pastry.Name);
                pastries.Add(new OrderPastry
                {
                    OrderID = order.ID,
                    PastryID = pastry.ID,
                    Amount = newPastry.Amount,
                    Comme = newPastry.Comments
                });
            }
            
            await _context.AddRangeAsync(pastries);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<Order2DTO> GetOrderAsync(int orderId)
    {
        var order = await _context.Order2s
            .Where(o => o.Id == orderId)
            .Select(o => new Order2DTO
            {
                Id = o.Id,
                CreatedAt = o.CreatedAt,
                FulfilledAt = o.FulfilledAt,
                Status = o.Status.Nam,
                Client = new Client2DTO()
                {
                    FirstName = o.Client.FirstName,
                    LastName = o.Client.LastName
                },
                Products = o.ProductOrders.Select(o => new ProductDTO()
                {
                    Name = o.Product.Name,
                    Price = o.Product.Price,
                    Amount = o.Amount
                }).ToList()
            }).FirstOrDefaultAsync(e => e.Id == orderId);
        
        if (order is null)
            throw new NotFoundException();
        return order;
    }

    public async Task UpdateOrderAsync(int orderId, [FromBody] Order2Request request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var order = await _context.Order2s
                .FirstOrDefaultAsync(o => o.Id == orderId);
            if (order is null)
                throw new NotFoundException("Order not found.");

            var status = await _context.Statuses
                .FirstOrDefaultAsync(s => s.Nam.Equals(request.StatusName));
            if (status is null)
                throw new NotFoundException("Status not found.");

            if (order.FulfilledAt != null)
                throw new ConflictException("Order is already fulfilled.");

            order.StatusId = status.Id;
            order.FulfilledAt = DateTime.Now;

            var relatedProducts = _context.ProductOrders.Where(po => po.OrderId == orderId);
            _context.ProductOrders.RemoveRange(relatedProducts);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}