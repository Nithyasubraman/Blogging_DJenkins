using BloggingSite;
using BloggingSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace BloggingSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificationOrigin",
                    builder => builder.WithOrigins("http://localhost:3000/")
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            }
            );



            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));

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

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.WebRootPath, "images")),
                RequestPath = "/wwwroot/images"
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowSpecificationOrigin");

            app.Run();
        }
    }
}

















//using BloggingSite;
//using BloggingSite.Controllers;
//using BloggingSite.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.FileProviders;
//using Microsoft.OpenApi.Models;
//using System.ComponentModel;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificationOrigin",
//        builder => builder.WithOrigins("http://localhost:3000/")
//        .AllowAnyHeader()
//        .AllowAnyOrigin()
//        .AllowAnyMethod());
//}
//           );

//builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));



//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//var app = builder.Build();



//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();

//}


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.UseCors("AllowSpecificationOrigin");

//app.Run();

//}
//}
//}






//app.UseAuthorization();

//app.MapControllers();

//// Configure the HTTP request pipeline.
//app.UseCors("CorsPolicy");

//app.Run();








//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//});




//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.WebRootPath, "images")),
//    RequestPath = "/wwwroot/images"
//});




//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",
//        Title = "Blogging Site",
//        Description = "An ASP.NET Core Web API"
//    });

//});




//builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));







//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blogging Site", Version = "v1" });
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = "JWT Authorization header using the Bearer scheme.",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey
//    });
//});








//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blogging Site");
//});

//// Enable static file serving (if needed)
//app.UseStaticFiles();


//builder.Services.AddScoped<ImagesController>();



//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.WebRootPath, "images")),
//    RequestPath = "/wwwroot/images"
//});








//cors

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy",
//        builder => builder.AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader());
//});