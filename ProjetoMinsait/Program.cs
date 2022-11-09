using Microsoft.EntityFrameworkCore;
using ProjetoMinsait.Data;
using ProjetoMinsait.Repository;
using ProjetoMinsait.Repository.Interfaces;

namespace ProjetoMinsait
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //docker e .env
            DotNetEnv.Env.Load();

            var server = builder.Configuration["DbServer"] ?? Environment.GetEnvironmentVariable("SQL_DB_SERVER");
            var port = builder.Configuration["DbPort"] ?? Environment.GetEnvironmentVariable("SQL_DB_PORT");
            var user = builder.Configuration["DbUser"] ?? Environment.GetEnvironmentVariable("SQL_DB_USER");
            var password = builder.Configuration["Password"] ?? Environment.GetEnvironmentVariable("SQL_DB_PASS");
            var database = builder.Configuration["Database"] ?? Environment.GetEnvironmentVariable("SQL_DB_DATABASE");

            //--- connection with sql server ---

            //local
            var connectionStringDB = builder.Configuration.GetConnectionString("DataBase");

            //Docker
            //var connectionStringDbDocker = $"Server={server}, {port};atabase={database};User={user};Password={password}";
            builder.Services.AddDbContext<DataContext>(
                    options => options.UseSqlServer(connectionStringDB)
                );


            //injecoes de dependencias
            builder.Services.AddScoped<IMotoristaRepositorio, MotoristaRepositorio>();
            builder.Services.AddScoped<ICobradorRepositorio, CobradorRepositorio>();
            builder.Services.AddScoped<IPassageiroRepositorio, PassageiroRepositorio>();
            builder.Services.AddScoped<IOnibusRepositorio, OnibusRepositorio>();
            builder.Services.AddScoped<IPassagemRepositorio, PassagemRepositorio>();

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