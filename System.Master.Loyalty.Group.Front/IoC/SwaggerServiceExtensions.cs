using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace App.API
{
	public static class SwaggerServiceExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "App System API v1.0", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});


				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							},
							Scheme = "oauth2",
							Name = "Bearer",
							In = ParameterLocation.Header,

						},
						new List<string>()
					}
				});
			});

			return services;
		}

		/// <summary>
		/// Extension to initialize the Swagger Documentation
		/// </summary>
		/// <param name="app"></param>
		/// <returns></returns>
		public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("v1.0/swagger.json", "Versioned API v1.0");

				c.DocumentTitle = "App System";
				c.DocExpansion(DocExpansion.None);
			});

			return app;
		}
	}
}
