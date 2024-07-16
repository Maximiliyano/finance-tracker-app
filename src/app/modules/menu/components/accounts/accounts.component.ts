import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

export interface Account {
  name: string;
  balance: number;
  totalIncome: number;
  totalExpense: number;
  transferOut: number;
  transferIn: number;
}

const ELEMENT_DATA: Account[] = [
  { name: 'Main Account', balance: 5000, totalIncome: 10000, totalExpense: 2000, transferOut: 500, transferIn: 1000 },
  { name: 'Savings Account', balance: 3000, totalIncome: 5000, totalExpense: 1000, transferOut: 300, transferIn: 200 },
];

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrl: './accounts.component.scss'
})
export class AccountsComponent implements OnInit {
  displayedColumns: string[] = ['name', 'balance', 'totalIncome', 'totalExpense', 'transferOut', 'transferIn', 'actions'];
  dataSource = new MatTableDataSource<Account>(ELEMENT_DATA);

  selectedAccount: Account = {
    name: '',
    balance: 0,
    totalIncome: 0,
    totalExpense: 0,
    transferOut: 0,
    transferIn: 0
  };

  @ViewChild(MatSort) sort!: MatSort;

  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
    this.dataSource.sort = this.sort;
  }

  openAccountDialog(): void {
    this.selectedAccount = {
      name: '',
      balance: 0,
      totalIncome: 0,
      totalExpense: 0,
      transferOut: 0,
      transferIn: 0
    };
  }

  saveAccount(): void {
    const existingAccountIndex = this.dataSource.data.findIndex(acc => acc.name === this.selectedAccount.name);
    if (existingAccountIndex !== -1) {
      this.dataSource.data[existingAccountIndex] = { ...this.selectedAccount };
    } else {
      this.dataSource.data = [...this.dataSource.data, { ...this.selectedAccount }];
    }
    this.selectedAccount = {
      name: '',
      balance: 0,
      totalIncome: 0,
      totalExpense: 0,
      transferOut: 0,
      transferIn: 0
    };
  }

  editAccount(account: Account): void {
    this.selectedAccount = { ...account };
  }

  deleteAccount(account: Account): void {
    this.dataSource.data = this.dataSource.data.filter((acc: Account) => acc !== account);
  }
}
