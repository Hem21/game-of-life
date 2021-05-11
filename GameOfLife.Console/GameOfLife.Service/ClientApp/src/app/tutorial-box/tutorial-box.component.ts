import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tutorial-box',
  templateUrl: './tutorial-box.component.html',
  styleUrls: ['./tutorial-box.component.css'],

})
export class TutorialBoxComponent {
  images = [
    { title: 'Selected grid', image: '../assets/selectexistinggrid.gif', content: 'You can play with a grid that already exists, you need to select the grid before playing'},
    { title: 'Create a grid', image: '../assets/creategrid.gif', content: 'Enter the size of your grid to play' },
  ];
 
}


