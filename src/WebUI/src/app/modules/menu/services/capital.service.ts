import { Injectable } from '@angular/core';
import { Capital } from '../models/capital-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.development';
import { AddCapitalRequest } from '../../capital/models/add-capital-request';
import { UpdateCapitalRequest } from '../../capital/models/update-capital-request';

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
