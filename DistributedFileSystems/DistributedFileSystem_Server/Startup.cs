using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(FileCenter.Startup))]

namespace FileCenter
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
