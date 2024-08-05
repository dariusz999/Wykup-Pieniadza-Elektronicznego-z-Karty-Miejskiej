//using FinalProjectDapper.Repositories;
//using FinalProjectDapper.Services;
using FinalProjectWabAPI.Db;
using FinalProjectWabAPI.Repositories;
using FinalProjectWabAPI.Services;

namespace FinalProjectWabAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<CustomerRepository>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<CardRepository>();
            builder.Services.AddScoped<CardService>();
            builder.Services.AddScoped<PaymentRepository>();
            builder.Services.AddScoped<PaymentService>();
            builder.Services.AddScoped<CardValidatorRepository>();
            builder.Services.AddScoped<CardValidatorService>();

            builder.Services.AddSingleton<IDapperContext, DapperContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

}
