import { Injectable } from '@angular/core';
import { Account } from '../models/account';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  constructor() { }

  getAll(): Account[] {
    return [
      {
        id: 1,
        name: 'Test',
        balance: 0,
        totalIncome: 0,
        totalExpense: 0,
        transferOut: 0,
        transferIn: 0,
        editable: false
      }
    ];
  }

  create(newAccount: Account) {
  }

  update(account: Account) {
  }

  delete(id: number): void {
  }
}
