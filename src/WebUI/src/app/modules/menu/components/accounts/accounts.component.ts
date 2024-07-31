import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { Account } from '../../models/account';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrl: './accounts.component.scss'
})
export class AccountsComponent implements OnInit {
  accounts: Account[];

  constructor(private readonly accountService: AccountService) { }

  ngOnInit(): void {
    this.accounts = this.accountService.getAll();
  }

  saveAccount(account: Account) {
    account.editable = false;

    this.accountService.update(account);
  }

  addAccount(): void {
    let newAccount: Account = {
      id: this.accounts.length + 1,
      name: 'Example',
      balance: 0,
      totalIncome: 0,
      totalExpense: 0,
      transferOut: 0,
      transferIn: 0,
      editable: false
    };

    this.accounts.push(newAccount);

    this.accountService.create(newAccount);
  }

  editAccount(account: Account): void {
    account.editable = !account.editable;
  }

  removeAccount(id: number): void {
    let index = this.accounts.findIndex(a => a.id == id);
    console.log("ID: " + id + "\nIndex: " + index);

    if (index == -1) {
      console.error("The account was not found.")
      return;
    }

    this.accounts.splice(index, 1);

    this.accountService.delete(id);
  }
}
