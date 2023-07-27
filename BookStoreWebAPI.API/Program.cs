using BookStoreWebAPI.API.Data;
using BookStoreWebAPI.API.Mappings;
using Microsoft.EntityFrameworkCore;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Injecting DbContext
builder.Services.AddDbContext<BookStoreDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConnectionString")));
//Injecting Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}