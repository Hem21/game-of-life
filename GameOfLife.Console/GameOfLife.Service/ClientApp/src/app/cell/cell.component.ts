import { Component, OnInit } from '@angular/core';
import { take } from "rxjs/operators";
import { BackEndService, Grid } from "../services/backend.service";
import { FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';



@Component({
  selector: "app-cell",
  templateUrl: "./cell.component.html"
})
export class CellComponent implements OnInit {
  private inputValidators = [Validators.required, Validators.min(1), Validators.max(20)];
  public formGroup: FormGroup = new FormGroup({
    rowAngularID: new FormControl("", this.inputValidators),
    columnAngularID: new FormControl("", this.inputValidators)
  });
  row: number;
  column: number;
  public grid: Grid;
  rowPosition: number;
  columnPosition: number;
  previousGrid: Grid;
  public hide: boolean = false;
  public show: boolean = true;
  score: number = 0;
  


  constructor(private backendService: BackEndService ) { }

  ngOnInit() {

  }

  showAndHide() {
    this.hide = true;
    this.show = false;
  }

  createGridClick(rowValue: number, columnValue: number) {
    if (this.formGroup.valid) {
      this.row = rowValue;
      this.column = columnValue;
      this.showAndHide();
      this.callBackend(rowValue, columnValue);
    }
  }

  callBackend(row: number, column: number) {
    this.backendService.requestGrid(row, column).pipe(take(1)).subscribe(result => {
      this.grid = result;
    });
  }


  selectCell(rowIndex: number, columnIndex: number) {
    this.rowPosition = rowIndex;
    this.columnPosition = columnIndex;
    this.backendService.setCells(this.grid, rowIndex, columnIndex).subscribe(result => {
      this.grid = result;
    })
  }

  updateGridClick() {
    var currentGrid = this.grid;
        
    if (JSON.stringify(currentGrid) == JSON.stringify(this.previousGrid)) {
      Swal.fire({
        icon: 'error',
        title: 'Game Over',
        text: 'Your score is:' + (this.score),
        showConfirmButton: false,
        footer: `
          <a class="btn" id="start-link" href="home">Start New Game</a>
          `
      })
    } else {
      this.backendService.updateGrid(this.grid).subscribe(result => {
        this.grid = result;
      })
    }
    this.previousGrid = currentGrid;
    
    
  }

  playGame() {
    var interval = setInterval(() => {

      var currentGrid = this.grid;
      const timeGrid = JSON.stringify(currentGrid);
      const previousTimeGrid = JSON.stringify(this.previousGrid);

      if (timeGrid === previousTimeGrid) {
          Swal.fire({
            icon: 'error',
            title: 'Game Over',
            showConfirmButton: false,
            text: 'Your score is ' + (this.score - 1),
            footer: `
            <a class="btn" id="start-link" href="home">Start New Game</a>
            `
          })
          clearInterval(interval);
      }
        this.backendService.updateGrid(this.grid).subscribe(result => {
          this.grid = result;
          this.previousGrid = currentGrid;
          this.calculateScore();
        })
    }, 500)
    
  }

  calculateScore() {

    this.score = this.score + 1;
  }

  getStartGrid(gridName: string) {
    this.backendService.getStartGrid(gridName).subscribe(result => {
      this.grid = result;
    })
    this.showAndHide();
  }


      
}
