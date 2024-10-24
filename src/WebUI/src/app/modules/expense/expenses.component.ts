import { Component, OnDestroy, OnInit } from '@angular/core';
import { ExpenseService } from './services/expense.service';
import { Expense } from './models/expense';
import { Subject, takeUntil } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ExpensesDialogComponent } from './components/expenses-dialog/expenses-dialog.component';
import { CapitalService } from '../capital/services/capital.service';
import { CategoryService } from '../../shared/services/category.service';
import { Category } from '../../core/models/category-model';
import { CategoryType } from '../../core/models/category-type';
import { CapitalResponse } from '../capital/models/capital-response';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrl: './expenses.component.scss'
})
export class ExpensesComponent implements OnInit, OnDestroy {
  expenses: Expense[] | null;
  capitals: CapitalResponse[] | null;
  categories: Category[] | null;
  expensesByCategory: number;

  private $unsubscribe = new Subject<void>;

  constructor(
    private readonly capitalService: CapitalService,
    private readonly categoryService: CategoryService,
    private readonly expenseService: ExpenseService,
    private readonly dialog: MatDialog) {}

  ngOnInit(): void {
    // TODO users capitals
    this.capitalService
      .getAll()
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response) => this.capitals = response
      });

    this.categoryService
      .getAll(CategoryType.Expenses)
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response) => this.categories = response
      });

    this.loadExpenses();
  }

  ngOnDestroy(): void {
    this.$unsubscribe.next();
    this.$unsubscribe.complete();
  }

  loadExpenses(): void {
    this.expenseService
      .getAll()
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response: Expense[]) => this.expenses = response.map(v => {
          if (v.purpose == null ||
              v.purpose == '') {
            v.purpose = '-';
          }

          return v;
        })
      });
  }

  // sumExpensesByCategories(): number {
  //   return this.expenses?
  //     .filter(x => this.categories?.find(c => c.id == x.capitalId))
  //     .map(x => x.amount)
  //     .reduce((accumulator, currentValue) => accumulator + currentValue, 0);
  // }

  add(): void {
    let dialogRef = this.dialog.open(ExpensesDialogComponent, {
      data: {
        categories: this.categories,
        capitals: this.capitals
      }
    });

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe((response) => {
        if (response) {
          this.loadExpenses();
        }
      });
  }
}
