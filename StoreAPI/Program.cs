
using Microsoft.EntityFrameworkCore;
using StoreAPI.AppServices.Products;
using StoreAPI.Entities;
using System.Text.Json.Serialization;

namespace StoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddXmlDataContractSerializerFormatters()
                  .AddJsonOptions(
            options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
        );

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IProductsAppService, ProductsAppService>();  
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options => {

                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnStr"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
