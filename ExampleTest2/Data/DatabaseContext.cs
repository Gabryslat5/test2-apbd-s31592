using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<OrderPastry> OrderPastries { get; set; }
    public DbSet<Pastry> Pastries { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    
    public DbSet<Client2> Client2s { get; set; }
    public DbSet<Order2> Order2s { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Product",
                Price = 10
            }
        );
        modelBuilder.Entity<ProductOrder>().HasData(
            new ProductOrder
            {
                ProductId = 1,
                OrderId = 1,
                Amount = 10
            }
        );
        modelBuilder.Entity<Order2>().HasData(
            new Order2
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                FulfilledAt = DateTime.Now,
                ClientId = 1,
                StatusId = 1
            }
        );
        modelBuilder.Entity<Status>().HasData(
            new Status
            {
                Id = 1,
                Nam = "Name"
            }
        );
        modelBuilder.Entity<Client2>().HasData(
            new Client2
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName"
            }
        );
        
        
        
        modelBuilder.Entity<Pastry>().HasData(
            new Pastry
            {
                ID = 1,
                Name = "Pastry",
                Price = 10,
                Type = "type"
            }
        );
        
        modelBuilder.Entity<OrderPastry>().HasData(
            new OrderPastry
            {
                OrderID = 1,
                PastryID = 1,
                Amount = 10,
                Comme = "Comme"
            }
        );
        
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                ID = 1,
                AcceptedAt = DateTime.Now,
                FulfilledAt = DateTime.Now,
                Comments = "Comment",
                EmployeeID = 1,
                ClientID = 1
            }
        );
        
        modelBuilder.Entity<Client>().HasData(
            new Client
            {
                ID = 1,
                FirstName = "Louis",
                LastName = "Armstrong",
            }
        );
        
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                ID = 1,
                FirstName = "Louis",
                LastName = "Armstrong",
            }
        );
    }
}