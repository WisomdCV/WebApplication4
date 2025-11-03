using Microsoft.EntityFrameworkCore;
using WISOMAPP.Infrastructure.Persistence;
using WISOMAPP.Application.Interfaces;
using WISOMAPP.Infrastructure.Repositories;
using WISOMAPP.Application;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssemblies(
        typeof(ApplicationAssemblyReference).Assembly 
    )
);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(cfg => {}, 
    typeof(ApplicationAssemblyReference).Assembly
);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();