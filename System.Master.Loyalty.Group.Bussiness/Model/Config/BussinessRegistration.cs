using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Master.Loyalty.Group.Bussiness.Article;
using System.Master.Loyalty.Group.Bussiness.Authentication;
using System.Master.Loyalty.Group.Bussiness.Branch;
using System.Master.Loyalty.Group.Bussiness.Common;
using System.Master.Loyalty.Group.Bussiness.Inventory;
using System.Master.Loyalty.Group.Bussiness.Order;
using System.Master.Loyalty.Group.Bussiness.Store;

namespace System.Master.Loyalty.Group.Bussiness.Model.Config
{
    public static class BussinessRegistration
    {

        public static IServiceCollection AddBussinessServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHttpContextUtility, HttpContextUtility>();
            services.AddScoped<IAuthenticationBussiness, AuthenticationBussiness>();
            services.AddScoped<IBranchBussiness, BranchBussiness>();
            services.AddScoped<IStoreBussiness, StoreBussiness>();
            services.AddScoped<IArticleBussiness, ArticleBussiness>();
            services.AddScoped<IInventoryBussiness, InventoryBussiness>();
            services.AddScoped<IOrderBussiness, OrderBussiness>();

            return services;
        }

    }
}
