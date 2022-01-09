using Microsoft.AspNetCore.Mvc.Formatters;
using DataStorage;

string connectionString = await File.ReadAllTextAsync("C:/Users/mjwaw/Revature/TextFile1.txt");

var builder = WebApplication.CreateBuilder(args);
bool prettyPrintJson = builder.Configuration.GetValue<string>("PrettyPrintJsonOutput") == "true";



builder.Services.AddControllers(options =>
{
    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

    var jsonFormatter = options.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().First();
    jsonFormatter.SerializerOptions.WriteIndented = prettyPrintJson;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository>(sp => new SqlRepository(connectionString));

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
