import {Component, OnDestroy, OnInit} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {Subject, takeUntil} from 'rxjs';
import {CapitalService} from '../../services/capital.service';
import {CapitalDialogComponent} from '../capital-dialog/capital-dialog.component';
import {PopupMessageService} from '../../../../shared/services/popup-message.service';
import {ExchangeService} from "../../../../shared/services/exchange.service";
import {Exchange} from "../../../../core/models/exchange-model";
import { currencyToSymbol } from '../../../../shared/components/currency/functions/currencyToSymbol.component';
import { CapitalResponse } from '../../models/capital-response';

@Component({
  selector: 'app-capital-list',
  templateUrl: './capital-list.component.html',
  styleUrl: './capital-list.component.scss',
})
export class CapitalListComponent implements OnInit, OnDestroy {
  capitals: CapitalResponse[];
  exchanges: Exchange[];
  mainCurrency: string = 'UAH';

  private unsubcribe$ = new Subject<void>;

  constructor(
    private readonly dialog: MatDialog,
    private readonly capitalService: CapitalService,
    private readonly popupMessageService: PopupMessageService,
    private readonly exchangeService: ExchangeService) { }

  ngOnInit(): void {
    // TODO execute user capitals
    this.executeCapitals();

    this.executeExchanges();

    // TODO execute currency by default from user settings for 'mainCurrency'
  }

  ngOnDestroy(): void {
    this.unsubcribe$.next();
    this.unsubcribe$.complete();
  }

  executeExchanges(): void {
    this.exchangeService
      .getAll()
      .pipe(takeUntil(this.unsubcribe$))
      .subscribe({
        next: (response) => this.exchanges = response
      });
  }

  symbol(value: string): string {
    return currencyToSymbol(value);
  };

  onCurrencyChange(newCurrency: string): void {
    // TODO update default currency for user here
    this.popupMessageService.success(`The default currency updated to <b>${newCurrency}</b>`);
    this.mainCurrency = newCurrency;
  }

  openToCreateCapitalDialog(): void {
    let dialogRef = this.dialog.open(CapitalDialogComponent);

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.unsubcribe$))
      .subscribe({
        next: (response: boolean) => {
          if (response) {
            this.executeCapitals();
          }
      }});
  }

  totalCapitalAmount(): number {
    return this.capitals?.reduce((accumulator, capital) => {
      if (capital.currency == this.mainCurrency) {
        return accumulator + capital.balance;
      }

      let amount = 0;
      let exchange = this.exchanges?.find(e => e.nationalCurrency === this.mainCurrency && e.targetCurrency === capital.currency);

      if (exchange) {
        amount = capital.balance * exchange.sale;
      }

      return amount + accumulator;
    }, 0) ?? 0;
  }

  removeCapital(id: number, event: MouseEvent): void {
    event.stopPropagation();
    event.preventDefault();

    this.capitalService
      .remove(id)
      .subscribe({
        next: () => {
          let index = this.capitals.findIndex(x => x.id == id);

          this.capitals.splice(index, 1);
          this.popupMessageService.success("The capital was successful removed.");
        }});
  }

  private executeCapitals(): void {
    this.capitalService
      .getAll()
      .pipe(takeUntil(this.unsubcribe$))
      .subscribe({
        next: (response) => {
          this.capitals = response;
        }
      });
  }
}
