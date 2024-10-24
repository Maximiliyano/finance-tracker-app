import { Injectable } from '@angular/core';
import { Capital } from '../models/capital-model';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.development';
import { AddCapitalRequest } from '../models/add-capital-request';
import { UpdateCapitalRequest } from '../models/update-capital-request';
import { CapitalResponse } from '../models/capital-response';

@Injectable({
  providedIn: 'root'
})
export class CapitalService {
  private baseApiUrl = environment.apiUrl + '/api/capitals';
  private capitals$ = new BehaviorSubject<CapitalResponse[]>([]);

  constructor(private readonly httpClient: HttpClient) { }

  getAll(): Observable<CapitalResponse[]> {
    if (!this.capitals$.value.length) {
      this.httpClient.get<CapitalResponse[]>(this.baseApiUrl)
        .pipe(tap(capitals => this.capitals$.next(capitals)))
        .subscribe();
    }

    return this.capitals$.asObservable();
  }

  getById(id: number): Observable<Capital> {
    return this.httpClient.get<Capital>(`${this.baseApiUrl}/${id}`);
  }

  add(request: AddCapitalRequest): Observable<number> {
    return this.httpClient.post<number>(this.baseApiUrl, request);
  }

  update(id: number, request: UpdateCapitalRequest): Observable<Object> {
    return this.httpClient.put(`${this.baseApiUrl}/${id}`, request);
  }

  remove(id: number): Observable<Object> {
    return this.httpClient.delete(`${this.baseApiUrl}/${id}`);
  }
}
