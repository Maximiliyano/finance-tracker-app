import { Component, OnDestroy, OnInit } from '@angular/core';
import { Exchange } from '../../models/exchange-model';
import { ExchangeService } from '../../../shared/services/exchange.service';
import { Subject, takeUntil } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ExchangeDialogComponent } from '../../../modules/home/components/exchange-dialog/exchange-dialog.component';
import { OverlayRef } from '@angular/cdk/overlay';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit, OnDestroy {
  exchanges: Exchange[] | null;
  authorizated: boolean;
  isSidebarExpanded: boolean;
  overlayRef: OverlayRef;

  private unsubscribe = new Subject<void>();

  constructor(
    private readonly dialog: MatDialog,
    private readonly exchangeService: ExchangeService) { }

  ngOnInit(): void {
    this.exchangeService
      .getAll()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(
        (exchanges) => {
          this.exchanges = exchanges;
        },
      (error) => console.error(error));
  }

  ngOnDestroy(): void {
    this.unsubscribe.complete();
    this.overlayRef.dispose();
  }

  openExchangeDialog(): void {
    this.dialog.open(ExchangeDialogComponent, {
      data: this.exchanges
    });
  }
}
