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
                //newһ��clientʵ�����޲ι����ӱ���appsettings.json�ļ���ȡ����
                var configClient = new ConfigClient();
                //ʹ��AddAgileConfig����һ���µ�IConfigurationSource
                config.AddAgileConfig(configClient);
                //��һ����������clientʵ�����Ա������ط�����ֱ��ʹ��ʵ����������
                //ConfigClient = configClient;
                //ע���������޸��¼�
                //configClient.ConfigChanged += ConfigClient_ConfigChanged;
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
