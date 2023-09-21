using ApiRestLoanInstallment.Infrastructure;
using ApiRestLoanInstallment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Rabbit MQ
builder.Services.AddScoped<IMessageProducer, FeePublisher>();
builder.Services.AddScoped<IMessageConsumer, FeeConsumer>();

//dbcontext
builder.Services.AddDbContext<FeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //conectando con contexto
    using (var scope = app.Services.CreateScope())
    {
        var feeDbContext = scope.ServiceProvider.GetRequiredService<FeeDbContext>();
        feeDbContext.Database.EnsureCreated();
    }

}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
