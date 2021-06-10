import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tutorial-box',
  templateUrl: './tutorial-box.component.html',
  styleUrls: ['./tutorial-box.component.css'],

})
export class TutorialBoxComponent {
  images = [
    { title: 'Welcome', picture: '../assets/creategrid.gif', content: 'Discover all the buttons in this app' },
    { id: '1', title: 'Create a grid', picture: '../assets/creategrid.gif', content: 'Enter the size of your grid to play' },
    { id: '2', title: 'Selected grid', picture: '../assets/selectexistinggrid.gif', content: 'You can play with a grid that already exists, you need to select the grid before playing' },
    { id: '3',title: 'hey', picture: '../assets/creategrid.gif', content: 'hehe' },

  ];



}
