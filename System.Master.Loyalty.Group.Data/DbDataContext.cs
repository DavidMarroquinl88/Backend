﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using System.Linq.Expressions;
using System.Master.Loyalty.Group.Data.Enums;
using System.Reflection;
using System.Reflection.Emit;

namespace System.Master.Loyalty.Group.Data
{
    public class DbDataContext : IdentityDbContext<ApplicationUser, ApplicationRol, int>
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options)
        {

        }

        public DbSet<StoreData> Stores { get; set; }

        public DbSet<BranchData> Branchs { get; set; }

        public DbSet<ArticleData> Articles { get; set; }

        public DbSet<InventoryData> Inventories { get; set; }

        public DbSet<OrderData> Orders { get; set; }

        public DbSet<OrderDetailData> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var tipoEntidad in builder.Model.GetEntityTypes())
            {
                foreach (var propiedad in tipoEntidad.GetProperties())
                {
                    if (propiedad.ClrType == typeof(DateTime) && propiedad.Name.Contains("CreatedDate", StringComparison.CurrentCultureIgnoreCase))
                    {
                        propiedad.SetDefaultValueSql("GetDate()");
                        propiedad.SetColumnType("datetime2");
                    }

                    if (propiedad.ClrType == typeof(DateTime) && propiedad.Name.Contains("LastModifiedDate", StringComparison.CurrentCultureIgnoreCase))
                    {
                        propiedad.SetColumnType("datetime2");
                    }

                    if (propiedad.ClrType == typeof(Status) && propiedad.Name.Contains("Status", StringComparison.CurrentCultureIgnoreCase))
                    {
                        propiedad.SetColumnType("int");
                        propiedad.SetDefaultValue(Status.Create);
                    }
                }

            }


            #region [Identities]
            builder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("Users");

                b.HasData(
                    new ApplicationUser()
                    {
                        Id = 1,
                        Apellidos = "David Marroquín López",
                        Nombre = "David",
                        Direccion = "Conocido",
                        Status = Status.Create,
                        CreatedDate = DateTime.Now,
                        UserName = "davidmarroquinl88@gmail.com",
                        NormalizedUserName = "DAVIDMARROQUINL88@GMAIL.COM",
                        Email = "davidmarroquinl88@gmail.com",
                        NormalizedEmail = "DAVIDMARROQUINL88@GMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash = "AQAAAAIAAYagAAAAEID7UGBbg04KModCwrOgHytkPh4OWE9Hwyg99Jo7e0kVm8hJryJ0+8szcv730oSgGQ==",
                        SecurityStamp = "FMKTDO4VIXEHP4VKXEQTSFPAXYJL5V2H",
                        ConcurrencyStamp = "06da3772-0af0-4292-8c7e-b558664db71d",
                        LockoutEnabled = true
                    }
                    );
            });

            builder.Entity<ApplicationRol>(b =>
            {
                b.ToTable("Roles");

                b.HasData(
                    new ApplicationRol() { Id = 1, Name = "administrador", NormalizedName = "ADMINISTRADOR" },
                    new ApplicationRol() { Id = 2, Name = "cliente", NormalizedName = "CLIENTE" }
                    );
            });

            builder.Entity<IdentityUserRole<int>>(b =>
            {
                b.ToTable("UserRoles");

                b.HasData(new IdentityUserRole<int>
                {
                    RoleId = 2,
                    UserId = 1
                });
            });

            builder.Entity<IdentityUserClaim<int>>(b =>
            {
                b.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<int>>(b =>
            {
                b.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<int>>(b =>
            {
                b.ToTable("UserTokens");
            });

            builder.Entity<IdentityRoleClaim<int>>(b =>
            {
                b.ToTable("RoleClaims");
            });
            #endregion

        }



    }
}
