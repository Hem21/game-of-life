import { Component, OnInit } from '@angular/core';
import { take } from "rxjs/operators";
import { BackEndService, Grid } from "../services/backend.service";

@Component({
  selector: "app-cell",
  templateUrl: "./cell.component.html"
})
export class CellComponent {
  row: number;
  column: number;
  public grid: Grid;


  constructor(private backendService: BackEndService) { }

  ngOnInit() {

  }

  handleClick(rowValue: number, columnValue: number) {
    this.row = rowValue;
    this.column = columnValue;
    console.log(this.row);
    console.log(this.column);

    this.callBackend(rowValue, columnValue);
  }

  callBackend(row: number, column: number) {
    this.backendService.requestGrid(row, column).pipe(take(1)).subscribe(result => {
      console.log('this is the result');
      console.log(result);
      this.grid = result;
    });
  }

  selectCell(rowIndex: number, columnIndex: number) {
    console.log({ rowIndex, columnIndex });
  }
}
