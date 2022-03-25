/* TODO 
- Issues with CORS, fix.  For now refer to Swagger for testing API and localhost:7013/index.html (works).
- Make a startup.cs
- Make the html dynamic.  Form with edit and delete buttons.  ( Halfway there, have the html and css )
- unit testing

*Maybe
- Maybe add "date created" for notes.
- FE framework?
- Switch to axios (maybe)
 */

global using noteTaker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using noteTaker.Models;
 
var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
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
}

app.UseHttpsRedirection();
    
app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();



