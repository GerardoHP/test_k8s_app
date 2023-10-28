using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using testk8sApp.Data.Data;
using testK8sApp.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add versioning
builder.Services
    .AddApiVersioning(opt =>
    {
        opt.AssumeDefaultVersionWhenUnspecified = true;
        opt.DefaultApiVersion = new ApiVersion(1, 0);
        // opt.ApiVersionReader = new UrlSegmentApiVersionReader();
        opt.ApiVersionReader = new QueryStringApiVersionReader("v");
        opt.ReportApiVersions = true;
    })
    .AddMvc();

// Add configuration to work with k8s and get the current working node
Info info = new();
builder.Configuration.GetSection(Info.SectionName).Bind(info);
builder.Services.AddSingleton(info);

// Add configuration to work with postgres with ef core
string connStr = builder.Configuration.GetConnectionString("Postgres_Db") ?? 
                 throw new ArgumentNullException($"no connection string");
builder.Services.AddDbContext<BloggingContext>(o => o.UseNpgsql(connStr));

// Add gRpc client
builder.Services.AddTransient<Client>();

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
