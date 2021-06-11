using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileConfig.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {

        private readonly ILogger<ConfigController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppSetting _appSetting;
        private readonly ConnectionStrings _connectionStrings;
        public ConfigController(ILogger<ConfigController> logger, IConfiguration configuration,
            IOptions<AppSetting> appSetting, IOptions<ConnectionStrings> connectionStrings)
        {
            _logger = logger;
            _configuration = configuration;
            _appSetting = appSetting.Value;
            _connectionStrings = connectionStrings.Value;
        }

        /// <summary>
        /// 使用IConfiguration读取配置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> Get()
        {
            var dicConfig = new Dictionary<string, string>();
            dicConfig.Add("AppSetting:IsProduction", _configuration["AppSetting:IsProduction"]);
            dicConfig.Add("AppSetting:AppId", _configuration["AppSetting:AppId"]);
            dicConfig.Add("AppSetting:AppSecret", _configuration["AppSetting:AppSecret"]);
            dicConfig.Add("AppSetting:IpList", _configuration["AppSetting:IpList"]);

            return dicConfig;
        }

        /// <summary>
        /// 使用IOptions读取配置
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get1")]
        public AppSetting Get1()
        {
            return _appSetting;
        }

        /// <summary>
        /// 使用IOptions读取配置(关联公共模块)
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get2")]
        public ConnectionStrings Get2()
        {
            return _connectionStrings;
        }

    }
}
