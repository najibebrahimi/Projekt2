using Microsoft.EntityFrameworkCore;
using Portfolio.EmailService;
using Portfolio.EmailService.Services;
using Portfolio.RESTAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://localhost:3000", "https://localhost:3000") // Allow specific origin
               .AllowAnyHeader() // Allow all headers
               .AllowAnyMethod(); // Allow all HTTP methods (GET, POST, etc.)
    });
});

var sqliteConnectionString = builder.Configuration.GetConnectionString("PortfolioDatabase") ??
    throw new InvalidOperationException("Connection string 'PortfolioDatabase' not found");

builder.Services.AddDbContext<ProjectContext>(opt =>
    opt.UseSqlite(sqliteConnectionString)
);

var useMockEmailService = builder.Configuration.GetValue<bool>("UseMockEmailService");

if (useMockEmailService)
{
    builder.Services.AddSingleton<IEmailService, MockEmailService>();
}
else
{
    var emailServiceConnectionString = builder.Configuration["AzureCommunicationServices:EmailConnectionString"] ??
    throw new InvalidOperationException("Connection string 'AzureCommunicationServices:EmailConnectionString' not found");

    var emailRecipientEmailAddress = builder.Configuration["AzureCommunicationServices:RecipientEmailAddress"] ??
        throw new InvalidOperationException("Configuration 'AzureCommunicationServices:RecipientEmailAddress' not found");

    builder.Services.AddSingleton<IEmailService>(provider => new EmailService(emailServiceConnectionString, emailRecipientEmailAddress));
}

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

app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();
