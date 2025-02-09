using MiniBank.Repository.Interfaces;
using MiniBank.Repository;
using MiniBank.Service.Interfaces;
using MiniBank.Service;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<ICustomerRepository, SqlClientCustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();




        var app = builder.Build();


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

