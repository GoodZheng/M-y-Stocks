using GetStocksDataService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

// 添加 Windows 和 Linux 平台支持
builder.Services.AddWindowsService();
builder.Services.AddSystemd();        

var host = builder.Build();
host.Run();
