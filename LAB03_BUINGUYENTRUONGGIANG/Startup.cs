using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab03_BuiNguyenTruongGiang.Startup))]
namespace Lab03_BuiNguyenTruongGiang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
