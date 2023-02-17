using CleanArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Implement Infrastruture DependencyInjection Container 
builder.Services.ImplementPersistence(builder.Configuration); //So with this line we have implemented all out services, by using anotherdependency 
//So In this project we are trying to run our dependency in another program which is the "CleanArchitecture.Infrastructure" program and calling in this
//project/program which is the "CleanArchitectureDI"program 
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


//So this is how to call an external dependency from another program "CleanArchitecture.Infrastructure(DependencyInjection class)".
//SO THIS PROJECT IS ADDING A DEPENDENCY CONTAINER/INFRASTRUCTURE TG INFRASTRUCTURE LAYER CLASS LIBARY