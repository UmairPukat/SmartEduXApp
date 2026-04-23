using SmartEduX.API.ExceptionHandling;
using SmartEduX.API.Middleware;
using SmartEduX.Application;
using SmartEduX.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Global unhandled exceptions → OperationResponse JSON (requires ProblemDetails registration).
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthorization();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseMiddleware<TokenClaimsMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();