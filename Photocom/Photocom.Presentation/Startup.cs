using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Photocom.Presentation.Startup))]
namespace Photocom.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
