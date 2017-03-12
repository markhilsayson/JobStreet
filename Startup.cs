using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobStreet.Startup))]
namespace JobStreet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
