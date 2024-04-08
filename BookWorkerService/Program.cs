/*using BookWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddHttpClient("BookAPI", client =>
{
    client.BaseAddress = new Uri("https://www.googleapis.com/books/v1/");
});
builder.Services.AddHttpClient("customEndpoints", client =>
{
    client.BaseAddress = new Uri("https://localhost:44311/api/service/app");
});

//injecting the worker service
builder.Services.AddHostedService<Worker>();
var host = builder.Build();
*//*host.Run();*/

