using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using testK8sApp.Data;
using testK8sApp.Data.Repositories;
using testK8sApp.Domain.Repositories;
using testK8sApp.Web;
using testK8sApp.Web.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
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
builder.Services.AddDbContext<PublishingContext>(o => o.UseNpgsql(connStr));

// Add gRpc client
builder.Services.AddTransient<Client>();

// Add Automapper configuration
builder.Services.AddAutoMapper(typeof(DataProfile));

// Add repositories as services temporal
// #####
builder.Services.AddTransient<IProofOfLifeRepository, ProofOfLifeRepository>();
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
// #####

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

#if DEBUG

// Only use migrations on development services not on production environments
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PublishingContext>();
    db.Database.Migrate();
}

#endif

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
