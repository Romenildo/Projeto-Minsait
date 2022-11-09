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
            //docker
            var server = builder.Configuration["DbServer"] ?? "sqldata";
            var port = builder.Configuration["DbPort"] ?? "1450";
            var user = builder.Configuration["DbUser"] ?? "romDb";
            var password = builder.Configuration["Password"] ?? "romDb12345";
            var database = builder.Configuration["Database"] ?? "LivrosDb";

            //--- connection with sql server ---

            //local
            //var connectionStringDB = builder.Configuration.GetConnectionString("DataBase");

            //Docker
            var connectionStringDbDocker = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";
            builder.Services.AddDbContext<DataContext>(
                    options => options.UseSqlServer(connectionStringDbDocker)
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