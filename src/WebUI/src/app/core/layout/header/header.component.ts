import { Component, OnDestroy, OnInit } from '@angular/core';
import { Exchange } from '../../models/exchange-model';
import { ExchangeService } from '../../../shared/services/exchange.service';
import { Subject, takeUntil } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { MenuDialogComponent } from '../../../modules/menu/components/menu-dialog/menu-dialog.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit, OnDestroy {
  exchanges: Exchange[] | null;
  authorizated: boolean;

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
        });
  }

  ngOnDestroy(): void {
    this.unsubscribe.complete();
  }

  toggleMenu(): void {
    this.dialog.open(MenuDialogComponent);
  }
}
