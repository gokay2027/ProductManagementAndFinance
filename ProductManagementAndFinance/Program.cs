using ProductManagementAndFinance.Application.Commands.Abstract;
using ProductManagementAndFinance.Application.Commands.Concrete;
using ProductManagementAndFinance.Application.Queries.Abstract;
using ProductManagementAndFinance.Application.Queries.Concrete;
using ProductManagementAndFinanceApi.Application.Commands.Abstract;
using ProductManagementAndFinanceApi.Application.Commands.Concrete;
using ProductManagementAndFinanceApi.Application.Queries.Abstract;
using ProductManagementAndFinanceApi.Application.Queries.Concrete;
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

#region Context Injection

//Context injection
builder.Services.AddDbContext<ProductManagementAndFinanceContext>();

#endregion Context Injection

#region Generic Repository Injection

//Generic repository
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

#endregion Generic Repository Injection

#region Entity Repositories Injection

//Entity repositories
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IStorageRepository, StorageRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IFinanceRepository, FinanceRepository>();

#endregion Entity Repositories Injection

#region Entity Command Services Injection

//Business Command Services
builder.Services.AddTransient<IProductCommandBusiness, ProductCommandBusiness>();
builder.Services.AddTransient<IUserCommandBusiness, UserCommandBusiness>();

#endregion Entity Command Services Injection

#region Entity Query Services Injection

//Business Query Services
builder.Services.AddTransient<IProductQuery, ProductQuery>();
builder.Services.AddTransient<ICategoryQuery, CategoryQuery>();
builder.Services.AddTransient<IStorageQuery, StorageQuery>();

#endregion Entity Query Services Injection

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