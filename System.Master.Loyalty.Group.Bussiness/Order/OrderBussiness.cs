using System.Master.Loyalty.Group.Data.Repositories.Order;
using System.Master.Loyalty.Group.Entities.Order;

namespace System.Master.Loyalty.Group.Bussiness.Order
{
    public class OrderBussiness : IOrderBussiness
    {
        private readonly IOrderRepository orderRepository;
        public OrderBussiness(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<OrderResponse> CreateOrder(OrderRequest request)
        {
            var result = await this.orderRepository.CreateOrder(request);

            return result;
        }

        public async Task<OrderResponse> ValidateQuiantityToProduct(OrderValidateRequest request)
        {
            var result = await this.orderRepository.ValidateStockToProduct(request.ArticleId, request.Quantity);

            return result;
        }
    }
}
