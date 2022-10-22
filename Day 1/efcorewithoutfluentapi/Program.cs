using Microsoft.EntityFrameworkCore;
using efcorewithoutfluentapi.Models;
using efcorewithoutfluentapi.Repositories;
using efcorewithoutfluentapi.Services;

namespace efcorewithoutfluentapi
{
    public class Program
{
    public static void Main(string[] args)
    {
           var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
         builder.Services.AddDbContext<BookStoreContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnString")));


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
        builder.Services.AddTransient<IAuthorServices, AuthorServices>();
        builder.Services.AddTransient<IBookRepository, BookRepository>();


        var app = builder.Build();
        // Add services to the container.
       
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

    