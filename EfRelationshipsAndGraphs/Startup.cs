using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EfRelationshipsAndGraphs.Startup))]
namespace EfRelationshipsAndGraphs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
