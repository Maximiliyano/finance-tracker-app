import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subject, takeUntil} from 'rxjs';
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
import {CategoryResponse} from "../../../../core/models/category-model";
import {CategoryType} from "../../../../core/types/category-type";
import {ExpenseDialogComponent} from "../expense-dialog/expense-dialog.component";

@Component({
  selector: 'app-expense-list',
  templateUrl: './expense-list.component.html',
  styleUrl: './expense-list.component.scss'
})
export class ExpenseListComponent implements OnInit, OnDestroy {
  capitals: CapitalResponse[] = [];
  categories: CategoryResponse[] = [];
  selectedCapital: CapitalResponse | null = null;

  totalCapitalsBalance: number = 0;
  totalCapitalsExpense: number = 0;

  periods: string[] = Object.values(Periods);
  defaultCurrency: string = 'UAH';
  defaultPeriod: string = Periods.Month;

  selectedPeriod: string = this.defaultPeriod;
  startDate: Date | null = null;
  endDate: Date | null = null;
  allTime: boolean = false;

  private $unsubscribe = new Subject<void>();

  constructor(private readonly categoryService: CategoryService,
              private readonly capitalService: CapitalService,
              private readonly dialog: MatDialog) {}

  ngOnInit(): void {
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
        this.startDate = this.endDate = today;
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

      case Periods.Custom:
        break;

      default:
        this.startDate = this.endDate = null;
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

    const dialogRef = this.dialog.open(DialogDatePickerComponent, { data: dialogProps });

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
    let dialogRef = this.dialog.open(ExpenseDialogComponent, {
      data: {
        capitals: this.capitals,
        categories: this.categories
      }
    });

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (success: boolean) => {
          if (success)
            this.fetchCategories();
        }
      })
  }

  symbol(value?: string): string {
    return currencyToSymbol(value ?? this.defaultCurrency);
  };

  onCapitalChange(capital: CapitalResponse | null): void {
    this.selectedCapital = capital;
  }

  getCapitalBalance(): number {
    return this.selectedCapital?.balance ?? this.totalCapitalsBalance;
  }

  getCapitalTotalExpenses(): number {
    return this.selectedCapital?.totalExpense ?? this.totalCapitalsExpense;
  }

  hasExpenses(): boolean {
    return (this.selectedCapital?.totalExpense ?? this.totalCapitalsExpense) !== 0;
  }

  fetchCategories(): void {
    this.categoryService
      .getAll(CategoryType.Expenses)
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response) => {
          this.categories = response
            .map(category => {
              category.totalExpensesPercent = this.calculatePercent(category.totalExpenses);
              return category;
            })
            .sort((a, b) => b.totalExpenses - a.totalExpenses);
        }
      });
  }

  fetchCapitals(): void {
    this.capitalService
      .getAll()
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response) => {
          this.capitals = response;
          this.totalCapitalsBalance = this.calculateCapitalsBalance();
          this.totalCapitalsExpense = this.calculateCapitalsExpense();
        }
      });
  }

  private calculatePercent(sum: number): string {
    return ((sum / this.totalCapitalsExpense) * 100).toFixed();
  }

  private calculateCapitalsBalance(): number {
    return this.capitals.reduce((sum, capital) => sum + capital.balance, 0);
  }

  private calculateCapitalsExpense(): number {
    return this.capitals.reduce((sum, capital) => sum + capital.totalExpense, 0);
  }

  protected readonly Periods = Periods;
}
