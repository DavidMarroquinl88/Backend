using System.Master.Loyalty.Group.Entities.Order;

namespace System.Master.Loyalty.Group.Data.Repositories.Order
{
    public interface IOrderRepository
    {
        Task<OrderResponse> CreateOrder(OrderRequest request);

        Task<OrderResponse> ValidateStockToProduct(int idArticle, int cantidad);

    }
}
