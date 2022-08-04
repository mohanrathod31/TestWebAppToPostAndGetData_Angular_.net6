using DotNETCoreWebApi.Interfaces;
using DotNETCoreWebApi.Models;
using DotNETCoreWebApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddOptions<FileLocationOptions>().Bind(builder.Configuration.GetSection(FileLocationOptions.FileLocation));
builder.Services.AddSingleton<IFileHelper, FileHelper>();
builder.Services.AddScoped<IUserService, UserService>();



builder.Services.AddCors(options => {
    options.AddPolicy("Cors", p => {
        p.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors("Cors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
