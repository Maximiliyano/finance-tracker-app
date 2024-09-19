import { Component, OnInit } from '@angular/core';
import { Capital } from '../../../menu/models/capital-model';
import { CapitalService } from '../../../menu/services/capital.service';
import { ActivatedRoute } from '@angular/router';
import { IncomeDialogComponent } from '../../../income/components/income-dialog/income-dialog/income-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { IncomeService } from '../../../income/services/income.service';
import { ExpenseService } from '../../../expense/services/expense.service';
import { Subject, takeUntil } from 'rxjs';
import { Income } from '../../../income/models/income';
import { Expense } from '../../../menu/components/expenses/expenses.component';
import { PopupMessageService } from '../../../../shared/services/popup-message.service';

@Component({
  selector: 'app-capital-details',
  templateUrl: './capital-details.component.html',
  styleUrl: './capital-details.component.scss'
})
export class CapitalDetailsComponent implements OnInit {
  private capitalId: number;

  capital: Capital | null;
  incomes: Income[] | null;
  expenses: Expense[] | null;
  unsubscribe = new Subject<void>;

  constructor(
    private readonly dialog: MatDialog,
    private readonly route: ActivatedRoute,
    private readonly popupMessageService: PopupMessageService,
    private readonly capitalService: CapitalService,
    private readonly incomeService: IncomeService,
    private readonly expenseService: ExpenseService) {}

  ngOnInit(): void {
    this.capitalId = this.route.snapshot.params['capital.id'];
    
    this.refresh(this.capitalId);
  }

  openAddIncomeDialog(): void {
    let dialogRef = this.dialog.open(IncomeDialogComponent, {
      data: this.capitalId
    });

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((response) => {
        if (response) {
          this.refresh(this.capitalId);
          this.popupMessageService.success("The capital was successful added.")
        }
      });
  }

  refresh(capitalId: number) {
    this.capitalService
      .getById(this.capitalId)
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((response) => this.capital = response);

    this.expenseService
      .getAll()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((response) => this.expenses = response);
    
    this.incomeService
      .getAll(capitalId)
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((response) => this.incomes = response);
  }

  openAddExpenseDialog(): void {
    
  }
}
