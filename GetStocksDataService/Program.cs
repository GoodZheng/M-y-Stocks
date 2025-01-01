using GetStocksDataService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

// ��� Windows �� Linux ƽ̨֧��
builder.Services.AddWindowsService();
builder.Services.AddSystemd();        

var host = builder.Build();
host.Run();
