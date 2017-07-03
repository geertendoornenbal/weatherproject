using System;
using System.Threading.Tasks;
using System.Threading;

public class WeatherDataRetriever
{
  CancellationToken mCancellationToken;

  public WeatherDataRetriever(CancellationToken aCancellationToken)
  {
    mCancellationToken = aCancellationToken;
  }

  public void Run()
  {
    Task.Run(() =>
    {
      PeriodicTask lTemperatureTask = new PeriodicTask(RetrieveTemperature,mCancellationToken);
      lTemperatureTask.Run(new TimeSpan(0,0,2)).Wait(); 
    });
    Task.Run(() =>
    {
      PeriodicTask lTemperatureTask = new PeriodicTask(RetrieveInsideTemperature,mCancellationToken);
      lTemperatureTask.Run(new TimeSpan(0,0,3)).Wait(); 
    });
  }

  void RetrieveTemperature()
  {
    Console.WriteLine("hoi");
  }

  void RetrieveInsideTemperature()
  {
    Console.WriteLine("doei");
  }
}