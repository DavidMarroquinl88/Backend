using System.Master.Loyalty.Group.Data.Model.Config;
using System.Master.Loyalty.Group.Bussiness.Model.Config;
using System.Text.Json.Serialization;
using App.API;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApiDocument();
builder.Services.AddDataServiceRegistration(builder.Configuration);
builder.Services.AddBussinessServiceRegistration(builder.Configuration);


//CORS


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                     builder => builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials()
                     .WithOrigins(
                                 "http://localhost:4200",
                                 "http://localhost:4300",
                                 "http://localhost:4000",
                                 "http://localhost:5000"));
});

// ===== Add Swagger Documentation ========
builder.Services.AddSwaggerDocumentation();


builder.Services.AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); // Permitir todos los orígenes
    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET");
    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
    await next();
});

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();

//Use Cors
app.UseCors("CorsPolicy");


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
