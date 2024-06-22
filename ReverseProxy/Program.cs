
using System.Security.Cryptography.X509Certificates;
using ReverseProxy.Services;

namespace ReverseProxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITodoService, TodoService>();

            //Dodanie PerSpace klienta
            builder.Services.AddHttpClient("TodoAppClient", httpClient =>
            {
                httpClient.BaseAddress = new Uri("http://perspace.api:8080/");
            });

            //Dodanie Backoffice klienta
            builder.Services.AddHttpClient("TodoAppBackoffice", httpClient =>
            {
                httpClient.BaseAddress = new Uri("http://backoffice:8080/");
            });

            var app = builder.Build();

     
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
