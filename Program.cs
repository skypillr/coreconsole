using System;
using System.IO;
using AppUtil;
using AppUtil.Mediator;
using Microsoft.Extensions.Configuration;

namespace coreconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), ""))
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
             
          　
            CmdHelper.StartEnv(() =>
            {
                 var ev=ExecuteEnvironment.Instance;
ev.AddCmdByAttributeLite(new DefaultScanTargetAssembly(CmdHelper.GetAssemblyLoadedToAddCmd("AssembleFilesToLoaded", x=>configuration.GetSection(x).Value)))
.AddFiltersByAttribute(new DefaultScanTargetAssembly(CmdHelper.GetAssemblyLoadedToAddCmd("AssembleFilterFilesToLoaded", x => configuration.GetSection(x).Value)));
                return ev;
            });  
        }
    }
}
