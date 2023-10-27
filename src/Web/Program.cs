using Microsoft.EntityFrameworkCore;
using testK8sApp.Web;
using testK8sApp.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddApiVersioning();

Info info = new();
builder.Configuration.GetSection(Info.SectionName).Bind(info);
builder.Services.AddSingleton(info);

string connStr = builder.Configuration.GetConnectionString("Postgres_Db") ?? 
                 throw new ArgumentNullException($"no connection string");
builder.Services.AddDbContext<BloggingContext>(o => o.UseNpgsql(connStr));
#if DEBUG


#endif

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
