using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace weatherconsole
{    
  class Program
  {
    public static IConfigurationRoot Configuration { get; set; }

    static void Main(string[] args)
    {
      var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appconfig.json");

      Configuration = builder.Build();


      CancellationToken lToken = new CancellationToken();
      WeatherDataRetriever lWeatherDataRetriever = new WeatherDataRetriever(lToken, Configuration["OpenWeatherApiId"]);
      lWeatherDataRetriever.Run();
      while(!lToken.IsCancellationRequested)
      {
        System.Threading.Thread.Sleep(10);
      }
    }
  }
}
