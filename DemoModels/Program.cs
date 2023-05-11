using System.Data;
using System.Data.SqlClient;

using DR = DAL.Repositories;
using DS = DAL.Services;
using BLL.Repositories;
using BLL.Services;

namespace DemoModels
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("default");
            // Add services to the container.
            builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
            builder.Services.AddScoped<DR.IProductRepository, DS.ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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