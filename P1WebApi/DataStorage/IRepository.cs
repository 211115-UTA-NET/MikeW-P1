using P1WebApi.Models;
using P1WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using P1ConsoleApp;

namespace P1WebApi.Controllers
{
    public interface IRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(string custId);
    }
}