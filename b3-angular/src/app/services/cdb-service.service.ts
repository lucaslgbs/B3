import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CdbServiceService {

  url: string = "http://localhost:5235/api/cdb/calculate";

  constructor(private http: HttpClient) {}

  calculate(value: number, months: number) {

    var data = {
      value: value,
      months: months
    }

    return this.http.post(this.url, data);
  }
}
