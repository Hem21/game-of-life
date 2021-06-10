import { HttpClient} from '@angular/common/http';
import { Component, NgModule, OnInit } from '@angular/core';
import { JoyrideModule, JoyrideStepComponent} from 'ngx-joyride';
import { BackEndService, Grid } from '../services/backend.service';


@Component({
  selector: 'app-meteo',
  templateUrl: './meteo.component.html',
  styleUrls: ['./meteo.component.css']
  
})

export class MeteoComponent implements OnInit {
  /* weather: Weather = new Weather();*/
  WeatherData: any;
  public hide: boolean = false;
  public show: boolean = true;
  public grid: Grid;
  row: number;
  column: number;
  public previousGrid: Grid;
  weatherDescription: any;
  currentGrid: Grid;



  constructor(private backendService: BackEndService,
    private http: HttpClient) {

  }

  ngOnInit() {
    this.WeatherData = {
      main: {},
    };


  }

  showAndHide() {
    this.hide = true;
    this.show = false;
  }

  getWeatherData(chosenCityID: string) {
    var address = 'https://api.openweathermap.org/data/2.5/weather?q=';
    var api = '&APPID=0e1b3709b6a617e669dc0e11f9447a30';
    return fetch(address + chosenCityID + api)
      
     
  }

  setWeatherData(data) {

    this.WeatherData = data;

    this.WeatherData.temperature = (this.WeatherData.main.temp - 273.15).toFixed(0);
    this.weatherDescription = this.WeatherData.weather[0].main;
    this.WeatherData.city = (this.WeatherData.name);
    this.WeatherData.country = (this.WeatherData.sys.country);
  }

  showWeather(rowValue: number, columnValue: number, weatherDescription, chosenCityID) {

    this.row = rowValue;
    this.column = columnValue;
    this.showAndHide();
  this.getWeatherData(chosenCityID)
    .then(response => response.json())
    .then(data => {
      this.setWeatherData(data);
     
    
    console.log(this.WeatherData);

     this.callWeatherBackend(this.weatherDescription);
    });
  }

  callWeatherBackend(weatherDescription) {

    if (weatherDescription === "Clouds") {
      this.backendService.getWeatherGrid('clouds').subscribe(result => {
        this.grid = result;
      });
      this.playNonStop();
    }

    else if (weatherDescription === "Clear") {
      this.backendService.getWeatherGrid('clear').subscribe(result => {
        this.grid = result;
      });
      this.playNonStop();
    }

    else if (weatherDescription === "Rain") {
      this.backendService.getWeatherGrid('rain').subscribe(result => {
        this.grid = result;
      });
      this.playNonStop();
    }
    else
      console.log("the Meteo is broken");

  }

  playNonStop() {
    var interval = setInterval(() => {

      var currentGrid = this.grid;
      const timeGrid = JSON.stringify(currentGrid);
      const previousTimeGrid = JSON.stringify(this.previousGrid);

      if (timeGrid !== previousTimeGrid) {
        this.backendService.updateGrid(this.grid).subscribe(result => {
          this.grid = result;
          this.previousGrid = currentGrid;
        })

      }
      else {
        this.callWeatherBackend(this.weatherDescription);
        clearInterval(interval);
        
      }
      

    }, 1000)

    
  }
}



  
  



