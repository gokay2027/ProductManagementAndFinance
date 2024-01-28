using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Commands.Concrete;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Application.Queries.Concrete;
using ProductManagementAndFinanceData;
using ProductManagementAndFinanceData.Repository.Abstract;
using ProductManagementAndFinanceData.Repository.Contract;
using ProductManagementAndFinanceData.Repository.EntityRepository;
using ProductManagementAndFinanceData.Repository.EntityRepository.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context injection
builder.Services.AddDbContext<ProductManagementAndFinanceContext>();
//Generic repository
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//Base Repositories
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
//Business Services
builder.Services.AddTransient<IProductCommandBusiness, ProductCommandBusiness>();
builder.Services.AddTransient<IProductQuery, ProductQuery>();

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