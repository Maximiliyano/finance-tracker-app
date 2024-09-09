import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Income } from '../models/income';

@Injectable({
  providedIn: 'root'
})
export class IncomeService {
  add(request: Income) {
    throw new Error('Method not implemented.');
  }

  constructor(private readonly http: HttpClient) { }
}
