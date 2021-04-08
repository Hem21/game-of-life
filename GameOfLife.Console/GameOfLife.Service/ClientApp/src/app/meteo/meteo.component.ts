import { HttpClient} from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BackEndService, Grid } from '../services/backend.service';


@Component({
  selector: 'app-meteo',
  templateUrl: './meteo.component.html',
  styleUrls: ['./meteo.component.css']
})
export class MeteoComponent implements OnInit {

  WeatherData: any;
  public hide: boolean = false;
  public show: boolean = true;
  public grid: Grid;
  row: number;
  column: number;
  public previousGrid: Grid;


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

  
  showWeatherWilmslow(rowValue: number, columnValue: number, gridWeatherStatus) {
    this.row = rowValue;
    this.column = columnValue;
    this.showAndHide();
    this.getWeatherDataWilmslow();
    console.log(this.WeatherData);
    this.callWeatherBackend(gridWeatherStatus);
  }


  callWeatherBackend(gridWeatherStatus) {
    if (this.WeatherData.description = "Clouds")
    {
      this.backendService.getWeatherGrid('clouds').subscribe(result => {
        this.grid = result;
      });
      this.playNonStop();
    }

    else if (this.WeatherData.description = "Sun")
    {
      this.backendService.getWeatherGrid('sun').subscribe(result => {
        this.grid = result;
      });
      this.playNonStop();
    }
      else 
      console.log("the Meteo is broken");
    
}


  getWeatherDataWilmslow() {
    fetch('https://api.openweathermap.org/data/2.5/weather?q=wilmslow,uk&APPID=0e1b3709b6a617e669dc0e11f9447a30')
      .then(response=>response.json())
      .then(data =>{this.setWeatherData(data);})

  }

  setWeatherData(data) {
    this.WeatherData = data;
    this.WeatherData.temp_celcius = (this.WeatherData.main.temp - 273.15).toFixed(0);
    this.WeatherData.description = (this.WeatherData.weather[0].main);
    this.WeatherData.city = (this.WeatherData.name);
    this.WeatherData.country = (this.WeatherData.sys.country);
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
        this.callWeatherBackend(this.grid);
        clearInterval(interval);
      }

     
    }, 1000)

  }
 
  }


  
  



