using HotelManagementSystem.Data;
using HotelManagementSystem.Repositories.Interfaces;
using HotelManagementSystem.Repositories.Implementation;
using HotelManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using hotel_system.Services;

// Create the service collection
var services = new ServiceCollection();

// Add DbContext with connection string
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HotelDb;Trusted_Connection=True;"));

// Register repositories
services.AddScoped<IRoomRepository, RoomRepository>();

// Register services
services.AddScoped<RoomServices>();
services.AddScoped<GuestServices>();
services.AddScoped<BookingServices>();
services.AddScoped<ReviewServices>();

// Build the service provider (DI container)
var provider = services.BuildServiceProvider();

// Resolve your service (example: RoomServices)
var roomService = provider.GetRequiredService<RoomServices>();

// Sample testing (remove later):
Console.WriteLine("==== Hotel System Console ====");
Console.Write("Enter room number: ");
int roomNumber = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Enter daily rate: ");
decimal rate = decimal.Parse(Console.ReadLine() ?? "0");

roomService.AddRoom(new()
{
    RoomNumber = roomNumber,
    DailyRate = rate,
    IsReserved = false
});

Console.WriteLine("Room added successfully!");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
