import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';
import { ExpenseResponse } from '../models/expense-response';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  private baseUrl = environment.apiUrl + "/api/expenses";

  constructor(private readonly http: HttpClient) { }

  getAll(capitalId: number | null): Observable<ExpenseResponse[]> {
    return this.http.get<ExpenseResponse[]>(this.baseUrl);
  }

  add(request: any): Observable<number> {
    return this.http.post<number>(this.baseUrl, request);
  }
}
