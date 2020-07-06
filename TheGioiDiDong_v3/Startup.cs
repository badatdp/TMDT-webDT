using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheGioiDiDong_v3.Startup))]
namespace TheGioiDiDong_v3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
