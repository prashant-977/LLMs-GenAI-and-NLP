// RAGApp/Program.cs

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure user secrets (add this to the existing builder configuration)
builder.Configuration.AddUserSecrets<Program>();

// 2. Register any necessary services (e.g., HttpClient or other custom services)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Optional: If you have services for handling file uploads, recommendations, etc., register them here
// builder.Services.AddScoped<IYourService, YourServiceImplementation>();

var app = builder.Build();

// Enable Swagger for API documentation (optional but helpful for testing)
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run the app
app.Run();
