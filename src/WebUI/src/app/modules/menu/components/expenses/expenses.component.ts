import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ExpensesDialogComponent } from './expenses-dialog/expenses-dialog.component';
import { MatSort } from '@angular/material/sort';

export interface Expense {
  name: string;
  amount: number;
  purpose: string;
  date: Date;
}

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrl: './expenses.component.scss'
})
export class ExpensesComponent implements OnInit {
  displayedColumns: string[] = ['name', 'amount', 'date', 'actions'];
  dataSource = new MatTableDataSource<Expense>();

  @ViewChild(MatSort) sort!: MatSort;

  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
    this.dataSource.sort = this.sort;
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(ExpensesDialogComponent, {
      width: '250px',
      data: {name: '', amount: 0, date: new Date()}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.dataSource.data = [...this.dataSource.data, result];
      }
    });
  }

  editExpense(expense: Expense): void {
    const dialogRef = this.dialog.open(ExpensesDialogComponent, {
      width: '250px',
      data: {...expense}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const data = this.dataSource.data;
        const index = data.findIndex(item => item === expense);
        data[index] = result;
        this.dataSource.data = data;
      }
    });
  }

  deleteExpense(expense: Expense): void {
    const data = this.dataSource.data.filter(item => item !== expense);
    this.dataSource.data = data;
  }

  getTotalAmount(): number {
    return this.dataSource.data.reduce((acc, curr) => acc + curr.amount, 0);
  }
}
