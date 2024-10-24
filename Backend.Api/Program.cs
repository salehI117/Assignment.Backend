using Backend.Application.Services;
using Backend.Domain.Interface;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cert = new X509Certificate2("C:/Users/muhammad mazdak/Downloads/RavenDB-6.2.0-windows-x64/Server/cluster.server.certificate.salehimran.pfx");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDocumentStore>(serviceProvider =>
{
    var store = new DocumentStore
    {
        Urls = new[] { "https://a.salehimran.ravendb.community/" }, 
        Database = "AssignmentDb",
        Certificate = cert

    };
    store.Initialize();
    return store;
});

builder.Services.AddScoped<IDocumentSession>(serviceProvider =>
{
    var store = serviceProvider.GetRequiredService<IDocumentStore>();
    return store.OpenSession();
});
builder.Services.AddScoped<IPerson_Service, Person_Service>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",builder =>
    {
        builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
