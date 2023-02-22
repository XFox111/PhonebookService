using FluentValidation;
using PhonebookService.Domain.Models;
using PhonebookService.Domain.Validators;
using PhonebookService.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLogging(options =>
{
	options.AddConfiguration(builder.Configuration.GetSection("Logging"));
	options.AddConsole();
	options.AddDebug();
	options.AddEventSourceLogger();
});

builder.Services.AddControllers();

// Settings up infrastructure layer
builder.Services.ConfigureInfrastructure(builder.Configuration, enableSensitiveDataLogging: builder.Environment.IsDevelopment());

// Adding validators
builder.Services.AddScoped<IValidator<PhonebookRecord>, PhonebookRecordValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
	options.SwaggerDoc("v1", new() { Title = "PhonebookService API", Version = "v1" }));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PhonebookService API v1"));
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/api/v1/Phonebook"));

app.Run();
