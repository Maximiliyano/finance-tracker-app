import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Exchange } from '../../core/models/exchange-model';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {
  private baseApiUrl = environment.apiUrl + '/api/exchanges/';
  private exchanges$ = new BehaviorSubject<Exchange[]>([]);

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Exchange[]> {
    if (!this.exchanges$.value.length) {
      this.http.get<Exchange[]>(this.baseApiUrl)
        .pipe(tap(exchanges => this.exchanges$.next(exchanges)))
        .subscribe();
    }

    return this.exchanges$.asObservable();
  }
}
