import { Component, NgModule } from "@angular/core";
import { JoyrideModule, JoyrideStepComponent } from "ngx-joyride";

@NgModule({

  imports: [
    JoyrideModule.forChild()],
  entryComponents: [JoyrideStepComponent],

})

@Component({
  templateUrl: './home.component.html'
})

export class HomeComponent {
  public pageTitle = "Welcome to the Game Of Life!";
}
