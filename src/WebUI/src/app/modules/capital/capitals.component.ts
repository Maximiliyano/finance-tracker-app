import { CapitalApiService } from './services/capital-api.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Capital } from './models/capital';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-accounts',
  templateUrl: './capitals.component.html',
  styleUrl: './capitals.component.scss'
})
export class CapitalsComponent implements OnInit, OnDestroy {
  capitals: Capital[] = [];
  unsubscribe = new Subject<void>;

  constructor(private readonly capitalApiService: CapitalApiService) {}

  ngOnInit(): void {
    this.capitalApiService
      .getAll()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(
        (response) => this.capitals = response)
      }

  ngOnDestroy(): void {
    this.unsubscribe.complete();
  }
}
