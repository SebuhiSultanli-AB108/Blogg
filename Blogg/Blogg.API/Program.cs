using Blogg.BL;
using Blogg.DAL;
using Blogg.DAL.Context;
using Microsoft.EntityFrameworkCore;
using SwaggerThemes;

namespace Blogg.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<BloggDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("Phoenix"));
        });
        builder.Services.AddRepositories();
        builder.Services.AddService();
        builder.Services.AddFluentValidation();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddAutoMapper();
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(Theme.UniversalDark);
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
