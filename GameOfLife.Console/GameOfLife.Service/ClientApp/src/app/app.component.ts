import { SelectorContext } from '@angular/compiler';
import { Component } from '@angular/core';
import { JoyrideDirective, JoyrideModule, JoyrideService } from 'ngx-joyride';
import { JoyrideOptions } from 'ngx-joyride/lib/models/joyride-options.class';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  mainTitle = "Game of life";

  public hide: boolean = false;
  public show: boolean = true;

  stepContent = [
    'Press the next button to discover the different features of the app',
    'This is the main menu',
    'You can learn more about the rules here',
    'You can check the weather for the city of your choice',
  ];


  constructor(private readonly joyrideService: JoyrideService) { }


  showAndHide() {
    this.hide = true;
    this.show = false;
  }

  tour() {
    
    const options: JoyrideOptions = {
      steps: ['step1', 'step2', 'step3@home', 'step4@grid', 'step5', 'step6@app', 'step7'],
      stepDefaultPosition: 'bottom',

           
    }
 
    this.joyrideService.startTour(options);
    
    }

    finishTour(){
        Swal.fire({
          icon: 'success',
          title: 'Done',
          text: 'Well done the tutorial is over',
          showConfirmButton: true,
        })
    


    
  }


}

