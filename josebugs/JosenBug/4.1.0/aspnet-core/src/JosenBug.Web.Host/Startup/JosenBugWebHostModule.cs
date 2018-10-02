using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JosenBug.Configuration;

namespace JosenBug.Web.Host.Startup
{
    [DependsOn(
       typeof(JosenBugWebCoreModule))]
    public class JosenBugWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public JosenBugWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JosenBugWebHostModule).GetAssembly());
        }
    }
}
