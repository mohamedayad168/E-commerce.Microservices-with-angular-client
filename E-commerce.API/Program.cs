using E_commerce.API.Middlewares;
using E_commerce.Core;
using E_commerce.Core.Mappers;
using E_commerce.Infrastructre;
namespace E_commerce.API
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
            builder.Services.AddInfrastructure();
            builder.Services.AddCore();
            builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
            var app = builder.Build();
            app.UseExceptionHandlingMiddleware();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
