import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Income } from '../models/income';
import { Observable, of } from 'rxjs';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class IncomeService {
  private baseApiUrl = environment.apiUrl + '/api/incomes';

  constructor(private readonly http: HttpClient) { }

  add(request: any) {
    return this.http.post(this.baseApiUrl, request);
  }

  getAll(): Observable<Income[]> {
    return this.http.get<Income[]>(this.baseApiUrl);
  }

  getIncomesByPeriod(period: string): Observable<Income[]> {
    return of([]);
  }
}
