using System;
using System.Threading;
using System.Threading.Tasks;

namespace weatherconsole
{    
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      CancellationToken lToken = new CancellationToken();
      WeatherDataRetriever lWeatherDataRetriever = new WeatherDataRetriever(lToken);
      lWeatherDataRetriever.Run();
      while(!lToken.IsCancellationRequested)
      {
        System.Threading.Thread.Sleep(10);
      }
    }
  }
}
