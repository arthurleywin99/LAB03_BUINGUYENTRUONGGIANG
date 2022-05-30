using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAB03_BUINGUYENTRUONGGIANG.Startup))]
namespace LAB03_BUINGUYENTRUONGGIANG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
