using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Master.Loyalty.Group.Data.Repositories.Article;
using System.Master.Loyalty.Group.Data.Repositories.Branch;
using System.Master.Loyalty.Group.Data.Repositories.Inventory;
using System.Master.Loyalty.Group.Data.Repositories.Order;
using System.Master.Loyalty.Group.Data.Repositories.Store;
using System.Text;

namespace System.Master.Loyalty.Group.Data.Model.Config
{
    public static class DataRegistration
    {

        public static IServiceCollection AddDataServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JWTSettings>(configuration.GetSection("JwtSettings"));


            services.AddDbContext<DbDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"),
                b => b.MigrationsAssembly(typeof(DbDataContext).Assembly.FullName)));


            services.AddIdentity<ApplicationUser, ApplicationRol>()
                .AddEntityFrameworkStores<DbDataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(element =>
            {
                element.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"] ?? "#-%642!'¿°..EFDAS5U8543''!3445"))
                };
            });

            return services;
        }

    }
}
