import { Injectable } from '@angular/core';
import { Capital } from '../models/capital-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CapitalService {
  private baseApiUrl = environment.apiUrl + '/api/capitals';

  constructor(private readonly httpClient: HttpClient) { }

  getAll(): Observable<Capital[]> {
    return this.httpClient.get<Capital[]>(this.baseApiUrl);
  }

  add(capital: Capital) {
    return this.httpClient.post(this.baseApiUrl, capital);
  }
}
