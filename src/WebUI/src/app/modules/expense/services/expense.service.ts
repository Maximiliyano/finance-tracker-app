import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import { ExpenseResponse } from '../models/expense-response';
import { AddExpenseRequest } from '../models/add-expense-request';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  private baseUrl = environment.apiUrl + "/api/expenses";

  constructor(private readonly http: HttpClient) { }

  getAll(capitalId?: number): Observable<ExpenseResponse[]> {
    let params = new HttpParams();

    if (capitalId != null) {
      params = params.set("capitalId", capitalId);
    }

    return this.http.get<ExpenseResponse[]>(this.baseUrl, { params });
  }

  add(request: AddExpenseRequest): Observable<number> {
    return this.http.post<number>(this.baseUrl, request);
  }
}
