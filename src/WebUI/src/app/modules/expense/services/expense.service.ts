import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import { Expense } from '../models/expense';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  private baseUrl = environment.apiUrl + "/api/expenses";

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Expense[]> {
    return this.http.get<Expense[]>(this.baseUrl);
  }

  add(request: any): Observable<number> {
    return this.http.post<number>(this.baseUrl, request);
  }
}
