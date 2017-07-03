import {HttpClient} from 'aurelia-fetch-client';

export class App 
{
  private mTemperature: number;

  constructor()
  {
    this.mTemperature = this.RetrieveTemperature();
  }

  RetrieveTemperature(): number
  {
    let lClient = new HttpClient();

    let lTemperature;
    //lClient.fetch('http://api.openweathermap.org/data/2.5/weather?q=Veenendaal,nl&APPID=b838213c4958556abf26f9561d8943d7&units=metric')
    lClient.fetch('api/temperature')
    .then(response => response.json())
    .then(data => {
      //this.mTemperature = data.main.temp;
      this.mTemperature = data;
    });
    
    return lTemperature;
  }
}
