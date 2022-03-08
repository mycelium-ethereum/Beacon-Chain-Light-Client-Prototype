using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Lantern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //  Console.WriteLine(IsValidProof(proof[2], branches, 44, 24189255811072, hashTreeRoot));

    }
}
