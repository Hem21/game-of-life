import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CellComponent } from './cell/cell.component';
import { GridSetUpComponent } from './grid/grid.component';
import { RulesComponent } from './rules/rules.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { MatFormFieldModule, MatInputModule } from '@angular/material';
import { MeteoComponent } from './meteo/meteo.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CellComponent,
    GridSetUpComponent,
    RulesComponent,
    MeteoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "home", component: HomeComponent },
      { path: "grid", component: GridSetUpComponent },
      { path: "rules", component: RulesComponent },
      {path: "meteo", component: MeteoComponent },
      { path: " ", redirectTo: "home", pathMatch: "full" },
      { path: "**", redirectTo: "home", pathMatch: "full" }
    ], { useHash: true }),
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
