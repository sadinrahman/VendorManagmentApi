using Microsoft.EntityFrameworkCore;
using VendorManagmentApi.DBContext;
using VendorManagmentApi.Repositories.VendorContactRepositories;
using VendorManagmentApi.Repositories.VendorRepositories;
using VendorManagmentApi.Services.VendorContactServices;
using VendorManagmentApi.Services.VendorServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VendorManagement")));

builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IVendorContactRepository, VendorContactRepository>();
builder.Services.AddScoped<IVendorContactService , VendorContactService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
