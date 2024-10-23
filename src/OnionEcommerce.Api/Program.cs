using AspNetCore.Scalar;
using OnionEcommerce.Infrastructure.CrossCutting.Extensions.IOC;
using OnionEcommerce.Infrastructure.CrossCutting.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RavenDbSettings>(builder.Configuration.GetSection("RavenDbSettings"));
builder.Services.AddRavenDb();
builder.Services.AddRepositories();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddMappers();
builder.Services.AddControllers();
builder.Services.AddHealthChecks()
                .AddRavenDB(setup =>
                {
                    setup.Database = builder.Configuration.GetSection("RavenDbSettings:DatabaseName").Value;
                    setup.Urls = [builder.Configuration.GetSection("RavenDbSettings:Url").Value!];
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseScalar(options =>
    {
        options.UseTheme(Theme.Default);
        options.RoutePrefix = "doc";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
