using Agile.Config.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileConfig.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                //new一个client实例，无参构造会从本地appsettings.json文件读取配置
                var configClient = new ConfigClient();
                //使用AddAgileConfig配置一个新的IConfigurationSource
                config.AddAgileConfig(configClient);
                //找一个变量挂载client实例，以便其他地方可以直接使用实例访问配置
                //ConfigClient = configClient;
                //注册配置项修改事件
                //configClient.ConfigChanged += ConfigClient_ConfigChanged;
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
