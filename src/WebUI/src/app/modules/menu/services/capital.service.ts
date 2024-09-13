import { Injectable } from '@angular/core';
import { Capital } from '../models/capital-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CapitalService {
  private baseApiUrl = environment.apiUrl + '/api/capitals';

  constructor(private readonly httpClient: HttpClient) { }

  getAll(): Observable<Capital[]> {
    return this.httpClient.get<Capital[]>(this.baseApiUrl);
  }

  getById(id: number): Observable<Capital> {
    return this.httpClient.get<Capital>(`${this.baseApiUrl}/${id}`);
  }

  add(capital: Capital) {
    return this.httpClient.post(this.baseApiUrl, capital);
  }

  remove(id: number) {
    return this.httpClient.delete(`${this.baseApiUrl}/${id}`);
  }
}
