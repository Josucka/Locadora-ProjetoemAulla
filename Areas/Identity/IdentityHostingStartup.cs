using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Locadora.Areas.Identity.IdentityHostingStartup))]
namespace Locadora.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}