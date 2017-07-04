using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
public class WeatherDataRetriever
{
  CancellationToken mCancellationToken;
  string mOpenWeatherApiId;

  public WeatherDataRetriever(CancellationToken aCancellationToken, string aOpenWeatherApiID)
  {
    mCancellationToken = aCancellationToken;
    mOpenWeatherApiId = aOpenWeatherApiID;
  }

  public void Run()
  {
    Task.Run(() =>
    {
      PeriodicTask lTemperatureTask = new PeriodicTask(RetrieveAndStoreTemperature,mCancellationToken);
      lTemperatureTask.Run(new TimeSpan(0,0,2)).Wait(); 
    });
    // Task.Run(() =>
    // {
    //   PeriodicTask lTemperatureTask = new PeriodicTask(RetrieveInsideTemperature,mCancellationToken);
    //   lTemperatureTask.Run(new TimeSpan(0,0,3)).Wait(); 
    // });
  }

  void RetrieveAndStoreTemperature()
  {
    Task.Run(async () => {
      string lResult = await RetrieveTemperature();
      StoreTemperature(lResult);
    });
  }

  async Task<string> RetrieveTemperature()
  {    
    var lClient = new HttpClient();
    lClient.DefaultRequestHeaders.Accept.Clear();
    lClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    var lWeatherRequestTask = lClient.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=Veenendaal,nl&APPID="+mOpenWeatherApiId+"&units=metric");
    
    var lResult = await lWeatherRequestTask;  
    return lResult;  
  }

  void StoreTemperature(string aJsonMessage)
  {
    dynamic lJsonObject = JsonConvert.DeserializeObject(aJsonMessage);

    Console.WriteLine(lJsonObject["main"]["temp"]);
  }
}