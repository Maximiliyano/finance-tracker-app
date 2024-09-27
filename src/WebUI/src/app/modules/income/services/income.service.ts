import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Income } from '../models/income';
import { Observable } from 'rxjs';
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

  getAll(id: number): Observable<Income[]> {
    return this.http.get<Income[]>(this.baseApiUrl);
  }
}
