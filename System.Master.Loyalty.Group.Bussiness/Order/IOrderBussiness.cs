using System.Master.Loyalty.Group.Entities.Order;

namespace System.Master.Loyalty.Group.Bussiness.Order
{
    public interface IOrderBussiness
    {
        Task<OrderResponse> CreateOrder(OrderRequest request);

        Task<OrderResponse> ValidateQuiantityToProduct(OrderValidateRequest request);
    }
}
