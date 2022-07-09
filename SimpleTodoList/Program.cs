using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SimpleTodoList.Infrastructure;

namespace SimpleTodoList.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().InitData().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
