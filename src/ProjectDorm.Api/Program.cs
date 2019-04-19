using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ProjectDorm.Api
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main app method
        /// </summary>
        /// <param name="args">App arguments</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Method for creating web host builder
        /// </summary>
        /// <param name="args">App arguments</param>
        /// <returns><see cref="IWebHostBuilder"/> instance</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
