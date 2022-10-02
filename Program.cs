
using AudiophileBE.Services;
using AudiophileBE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AudiophileBE.DbContexts;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<AudiophileContext>(options =>
 //   options.UseSqlServer(builder.Configuration.GetConnectionString("AudiophileBEContext") ?? throw new InvalidOperationException("Connection string 'AudiophileBEContext' not found.")));

// Add services to the container.

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddCors();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// connecting DB 
builder.Services.AddDbContext<AudiophileContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "firstdotnet v1"));
    //c.RoutePrefix = string.Empty;
    
    
    app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


}
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}); 

//app.MapControllers();


app.Run();
