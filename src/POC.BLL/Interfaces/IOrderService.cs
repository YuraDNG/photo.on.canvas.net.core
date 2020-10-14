using System.Threading.Tasks;
using POC.BLL.DTO;
using POC.BLL.Model;
using POC.DAL.Entities;
using POC.DAL.Models;

namespace BLL.Interfaces
{
  public interface IOrderService
  {
    PagesList<Order> GetOrderPagesList(OrderParameters parameters);
    Task MakeOrderAsync(OrderDTO order);
  }
}