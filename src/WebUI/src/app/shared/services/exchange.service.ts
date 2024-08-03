import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Exchange } from '../../core/models/exchange-model';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {
  private baseApiUrl = '/api/exchanges/';

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Exchange[]> {
    return this.http.get<Exchange[]>(environment.apiUrl + this.baseApiUrl);
  }
}
