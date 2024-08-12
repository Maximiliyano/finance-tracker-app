import { Component, OnDestroy, OnInit } from '@angular/core';
import { Exchange } from '../../../../core/models/exchange-model';
import { Subject, takeUntil } from 'rxjs';
import { ExchangeService } from '../../../../shared/services/exchange.service';

@Component({
  selector: 'app-exchange-dialog',
  templateUrl: './exchange-dialog.component.html',
  styleUrl: './exchange-dialog.component.scss'
})
export class ExchangeDialogComponent implements OnInit, OnDestroy {
  exchanges: Exchange[] | null;

  private unsubcrible = new Subject<void>();

  constructor(private readonly exchangeService: ExchangeService) { }

  ngOnInit(): void {
    this.exchangeService
      .getAll()
      .pipe(takeUntil(this.unsubcrible))
      .subscribe((response) => {
        this.exchanges = response;
      })
  }

  ngOnDestroy(): void {
    this.unsubcrible.complete();
  }
}
