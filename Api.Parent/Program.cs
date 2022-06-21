using Api.Parent;


CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) =>
        {
            //builder.AddAppSettings(context.HostingEnvironment.EnvironmentName);
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder
                .UseStartup<Startup>();
        });
