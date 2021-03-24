import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackEndService {
  urlBase: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') urlBase: string) {
    console.log(urlBase);
    this.urlBase = urlBase;
  }

  requestGrid(row: number, column: number): Observable<Grid> {
    const url = `${this.urlBase}creategrid/`;
    const body = { row: row, column: column };
    return this.http.post<Grid>(url, body);
  }

  setCells(grid: Grid, rowIndex: number, columnIndex: number): Observable<Grid> {
    const url = `${this.urlBase}setcells/`;
    const body = { grid, rowIndex, columnIndex };
    return this.http.post<Grid>(url, body);
  }

  updateGrid(grid: Grid): Observable<Grid> {
    const url = `${this.urlBase}updategrid/`;
    const body = { grid };
    return this.http.post<Grid>(url, body);
  }
}

export class Grid {
  columns: number;
  rows: number;
}
