import {Component, OnDestroy, OnInit} from '@angular/core';
import {ExpenseService} from '../../services/expense.service';
import {Subject, takeUntil} from 'rxjs';
import {ExpenseResponse} from '../../models/expense-response';
import {CapitalResponse} from '../../../capital/models/capital-response';
import {currencyToSymbol} from '../../../../shared/components/currency/functions/currencyToSymbol.component';
import {MatDialog} from "@angular/material/dialog";
import {
  DialogDatePickerComponent,
  DialogDatePickerComponentProps
} from "../dialog-date-picker/dialog-date-picker.component";
import {CapitalService} from "../../../capital/services/capital.service";
import {Periods} from "../../models/periods";
import {CategoryService} from "../../../../shared/services/category.service";
import {CategoryType} from "../../../../core/models/category-type";
import {Category} from "../../../../core/models/category-model";

@Component({
  selector: 'app-expense-list',
  templateUrl: './expense-list.component.html',
  styleUrl: './expense-list.component.scss'
})
export class ExpenseListComponent implements OnInit, OnDestroy {
  expenses: ExpenseResponse[] = [];
  capitals: CapitalResponse[] = [];
  categories: Category[] = [];

  capital: CapitalResponse | null = null;
  totalCapitalsBalance: number;
  totalExpense: number;
  periods: string[] = [
    Periods.Day,
    Periods.Week,
    Periods.Month,
    Periods.Year,
    Periods.Custom
  ];

  defaultCurrency: string = 'UAH';
  defaultPeriod: string = Periods.Month;

  selectedPeriod: string = this.defaultPeriod;

  startDate: Date | null = null;
  endDate: Date | null = null;

  allTime: boolean;

  private $unsubscribe = new Subject<void>();

  constructor(private readonly expenseService: ExpenseService,
              private readonly categoryService: CategoryService,
              private readonly capitalService: CapitalService,
              private readonly dialog: MatDialog) {}

  ngOnInit(): void {
    //this.fetchExpenses();

    this.fetchCapitals();

    this.fetchCategories();

    this.updateDateRange();
  }

  ngOnDestroy(): void {
    this.$unsubscribe.next();
    this.$unsubscribe.complete();
  }

  updateDateRange() {
    const today = new Date();

    switch (this.selectedPeriod) {
      case Periods.Day:
        this.startDate = today;
        this.endDate = today;
        break;

      case Periods.Week:
        this.startDate = new Date(today.setDate(today.getDate() - 7));
        this.endDate = new Date();
        break;

      case Periods.Month:
        this.startDate = new Date(today.setMonth(today.getMonth() - 1));
        this.endDate = new Date();
        break;

      case Periods.Year:
        this.startDate = new Date(today.setFullYear(today.getFullYear() - 1));
        this.endDate = new Date();
        break;

      // TODO custom
      case Periods.Custom:
        break;

      default:
        this.startDate = null;
        this.endDate = null;
    }
  }

  selectTab(period: string): void {
    this.selectedPeriod = period;

    if (period == Periods.Custom) {
      this.openDialogDatePicker();
    } else {
      this.updateDateRange();
    }
  }

  openDialogDatePicker(): void {
    let dialogProps: DialogDatePickerComponentProps = {
      startDate: this.startDate,
      endDate: this.endDate,
      allTime: this.allTime,
    };
    let dialogRef = this.dialog.open(DialogDatePickerComponent, {
      data: dialogProps
    });

    dialogRef
      .afterClosed()
      .subscribe({
        next: (result: DialogDatePickerComponentProps) => {
          if (result) {
            this.startDate = result.startDate;
            this.endDate = result.endDate;
            this.allTime = result.allTime;
          }
        }
      });
  }

  openDialogAddExpense(): void {
  }

  symbol(value: string): string {
    return currencyToSymbol(value);
  };

  onCapitalChange(capital: CapitalResponse | null): void {
    this.capital = capital;
  }

  fetchCategories(): void {
    this.categoryService
      .getAll(CategoryType.Expenses)
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response) => this.categories = response
      });
  }

  fetchCapitals(): void {
    this.capitalService
      .getAll()
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response) => {
          this.capitals = response;
          this.totalCapitalsBalance = this.capitals.reduce((sum, capital) => sum + capital.balance, 0);
          this.totalExpense = this.capitals.reduce((sum, capital) => sum + capital.totalExpense, 0);
        }
      });
  }

  fetchExpenses(): void {
    this.expenseService
      .getAll(this.capital?.id ?? null)
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response) => {
          this.expenses = response;
        }
      });
  }

  protected readonly Periods = Periods;
}
