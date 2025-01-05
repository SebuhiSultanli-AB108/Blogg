using Blogg.BL;
using Blogg.BL.Services.UserService;
using Blogg.DAL;
using Blogg.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SwaggerThemes;

namespace Blogg.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme ,
                            Id= "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        builder.Services.AddDbContext<BloggDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("Phoenix"));
        });
        builder.Services.AddRepositories();
        builder.Services.AddService();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddJwtOptions(builder.Configuration);
        builder.Services.AddAuth(builder.Configuration);
        builder.Services.AddFluentValidation();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddAutoMapper();
        builder.Services.AddScoped<IUserService, UserService>();
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(Theme.UniversalDark);
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
