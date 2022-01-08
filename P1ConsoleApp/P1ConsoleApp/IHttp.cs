using P1ConsoleApp.DTOs;

namespace P1ConsoleApp
{
    public interface IHttp
    {
        Task<List<Order>> GetInventoryListAsync();
    }
}