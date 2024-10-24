import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IncomeDialogComponent } from './components/income-dialog/income-dialog/income-dialog.component';
import { IncomeService } from './services/income.service';
import { Income } from './models/income';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-income',
  templateUrl: './income.component.html',
  styleUrl: './income.component.scss'
})
export class IncomeComponent implements OnInit, OnDestroy {
  incomes: Income[];

  private unsubcribe$ = new Subject<void>();

  constructor(
    private readonly incomeService: IncomeService,
    private dialog: MatDialog) {}

  ngOnInit(): void {
    this.executeIncomes();
  }

  ngOnDestroy(): void {
    this.unsubcribe$.next();
    this.unsubcribe$.complete();
  }

  openIncomeDialog(): void {
    let dialogRef = this.dialog.open(IncomeDialogComponent);

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.unsubcribe$))
      .subscribe({
        next: (closed) => {
          if (closed) {
            this.executeIncomes();
          }
        }
      });
  }

  executeIncomes(): void {
    this.incomeService.getAll()
      .pipe(takeUntil(this.unsubcribe$))
      .subscribe({
        next: (response) => this.incomes = response
      });
  }
}
