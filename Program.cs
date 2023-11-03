using ContentCreator.Business.Service.ContentCreatorService;
using ContentCreator.Business.Service.VideoService;
using ContentCreator.Data.Entities;
using ContentCreator.Data.Repositories.ContentCreatorRepo;
using ContentCreator.Data.Repositories.VideoRepo;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// register DbContext
builder.Services.AddDbContext<ContentCreatorDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("MyConnection")));

//add service to interface
builder.Services.AddScoped<IContentCreator, ContentCreatorService>();
builder.Services.AddScoped<IVideoSerivce, VideoSerivce>();   
//
builder.Services.AddTransient<IContentCreatorRepo, ContentCreatorRepo>();
builder.Services.AddTransient<IVideoRepo, VideoRepo>();
// Add services to the container.

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
