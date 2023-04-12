using ApiWebVeiculo.Data;
using ApiWebVeiculo.Middlewares;
using ApiWebVeiculo.Repository;
using ApiWebVeiculo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiWebVeiculo
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

            //Configuração do EntityFrameworkSqlServer
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<VeiculoDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            //Adicionando as dependencias do repository
            builder.Services.AddScoped<IVeiculoRepository, VeiculoRepositoryImpl>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}