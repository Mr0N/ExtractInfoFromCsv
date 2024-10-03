using ExtractInfoFromCsv.Interface;
using ExtractInfoFromCsv.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IInfoOfTags>(a =>
{
    return new InfoOfTags(@"C:\Users\Desktop\test\resource.tags.csv");
});
builder.Services.AddScoped<ISaveDataToFile>(a => new DataToFile());
builder.Services.AddScoped<IWorkingWithInfo, WorkingWithInfo>();
builder.Services.AddHostedService<MainBackgroundService>();
var app = builder.Build();



app.Run();
