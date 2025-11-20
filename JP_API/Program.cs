
using Modelo.Aplication;
using Modelo.Aplication.Interface;
using Modelo.Infra;
using Modelo.Infra.Repositorio;
using Modelo.Infra.Repositorio.interfaces;

namespace JP_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            var builder = WebApplication.CreateBuilder(args);

            DbConnectionFactory dbConnectionFactory = new DbConnectionFactory(builder.Configuration);
            dbConnectionFactory.CriarTabelas();

            builder.Services.AddSingleton(dbConnectionFactory);
            builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            builder.Services.AddScoped<IAlunoApplication, AlunoApplication>();
            builder.Services.AddHttpClient<ICepService, CepService>();

            // Add services to the container.

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
