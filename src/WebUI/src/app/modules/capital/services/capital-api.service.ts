import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Capital } from '../models/capital';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CapitalApiService {
  private baseApiUrl = '/api/capitals';

  constructor(private readonly httpClient: HttpClient) { }

  getAll(): Observable<Capital[]> {
    return this.httpClient.get<Capital[]>(environment.apiUrl + this.baseApiUrl);
  }
}
