import { Component, OnInit } from '@angular/core';
import { take } from "rxjs/operators";
import { BackEndService, Grid } from "../services/backend.service";
import { NgForm } from '@angular/forms';

@Component({
  selector: "app-cell",
  templateUrl: "./cell.component.html"
})
export class CellComponent implements OnInit{
  row: number;
  column: number;
  public grid: Grid;
  rowPosition: number;
  columnPosition: number;
  public hide: boolean = false;
  public show: boolean = true;


  constructor(private backendService: BackEndService) { }

  ngOnInit() {

  }

  showAndHide() {
    this.hide = true;
    this.show = false;
  }

  showAndHideReverse() {
    this.hide = false;
    this.show = true;
  }



  trueOrFalse(td: string) {
    if (td = "true") {
      return true;
    } else {
      return false;
    }
  }

  createGridClick(rowValue: number, columnValue: number) {
    this.row = rowValue;
    this.column = columnValue;
    console.log(this.row);
    console.log(this.column);

    this.callBackend(rowValue, columnValue);
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
    this.backendService.updateGrid(this.grid).subscribe(result => {
      this.grid = result;
    })
  }


}
