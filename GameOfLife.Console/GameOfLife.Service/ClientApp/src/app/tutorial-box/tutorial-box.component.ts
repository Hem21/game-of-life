import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tutorial-box',
  templateUrl: './tutorial-box.component.html',
  styleUrls: ['./tutorial-box.component.css'],

})
export class TutorialBoxComponent {
  images = [
    { title: 'hello world', image: '../assets/creategrid.gif', content: 'You can check the rules by clicking on this tab'},
    { title: 'this is the second slide', image: 'https://images.unsplash.com/photo-1444703686981-a3abbc4d4fe3?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cGljdHVyZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&w=1000&q=80'},
    '/some/image/a.png',
    '/other/image/b.png',
    '/third/image/c.png',
    '/more/images/d.png',
  ];
 
}


