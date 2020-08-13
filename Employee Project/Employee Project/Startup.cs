using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Employee_Project.Startup))]
namespace Employee_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
