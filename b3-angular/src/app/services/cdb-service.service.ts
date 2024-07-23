import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { InvestmentProjection } from '../models/investment-projection';

@Injectable({
  providedIn: 'root'
})
export class CdbServiceService {

  url: string = "http://localhost:5235/api/calculator/cdb/calculate";

  constructor(private http: HttpClient) {}

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
  
  calculate(value: number, months: number): Observable<InvestmentProjection> {

    var data = {
      value: value,
      months: months
    }

    return this.http.post<InvestmentProjection>(this.url, data).pipe(catchError(this.handleError));
  }
}
