import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Expense } from '../../menu/components/expenses/expenses.component';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  private baseUrl = environment.apiUrl + "/api/expenses"; 

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Expense[]> {
    return this.http.get<Expense[]>(this.baseUrl);
  }
}
