import { Component, OnDestroy, OnInit } from '@angular/core';
import { Capital } from '../../models/capital-model';
import { CapitalService } from '../../services/capital.service';
import { Subject, takeUntil } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-accounts',
  templateUrl: './capitals.component.html',
  styleUrl: './capitals.component.scss'
})
export class CapitalsComponent implements OnInit, OnDestroy {
  capitals: Capital[];

  private unsubcribe = new Subject<void>;

  constructor(
    private readonly dialog: MatDialog,
    private readonly capitalService: CapitalService) { }

  ngOnInit(): void {
    this.capitalService
      .getAll()
      .pipe(takeUntil(this.unsubcribe))
      .subscribe((response) => {
        this.capitals = response;
      });
  }

  ngOnDestroy(): void {
    this.unsubcribe.complete();
  }

  createCapital(): void {

  }
}
