using System.Master.Loyalty.Group.Entities.Order;

namespace System.Master.Loyalty.Group.Data.Repositories.Order
{
    public class OrderRepository : IOrderRepository
    {

        private readonly DbDataContext db;

        public OrderRepository(DbDataContext dbDataContext)
        {
            db = dbDataContext;
        }
        public async Task<OrderResponse> CreateOrder(OrderRequest request)
        {
            var itemOrder = new OrderData()
            {
                Total = request.Total,
                UserId = request.UserId
            };

            var articlesDetail = request.OrderDetail.Select(e => new OrderDetailData()
            {
                Order = itemOrder,
                ArticleId = e.ArticleId,
                Quantity = e.Quantity
            }).ToList();


            db.Orders.Add(itemOrder);
            db.OrderDetails.AddRange(articlesDetail);

            await db.SaveChangesAsync();

            return new OrderResponse()
            {
                IsSuccess = true
            };
        }

        public async Task<OrderResponse> ValidateStockToProduct(int idArticle, int cantidad)
        {
            var existencia = this.db.Inventories
                .Where(e => e.Article.Id == idArticle && e.Article.Status != Enums.Status.Delete)
                .Select(e => e.Stock)
                .Sum();

            var articleExits = existencia >= cantidad;


            var result = await Task.Run(() =>
             {
                 var result = new OrderResponse()
                 {
                     IsSuccess = articleExits,
                     MessageError = articleExits == false ? "No hay suficiente producto en almacén, actualmente existen: " + existencia + " artículos" : "",
                     MessageSuccess = articleExits == true ? "Hay suficientes productos para agregar" : ""
                 };

                 return result;
             }
            );

            return result;
        }
    }
}
