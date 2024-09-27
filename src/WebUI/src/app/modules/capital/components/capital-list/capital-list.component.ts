import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, takeUntil } from 'rxjs';
import { Capital } from '../../../menu/models/capital-model';
import { CapitalService } from '../../../menu/services/capital.service';
import { CapitalDialogComponent } from '../capital-dialog/capital-dialog.component';
import { PopupMessageService } from '../../../../shared/services/popup-message.service';

@Component({
  selector: 'app-capital-list',
  templateUrl: './capital-list.component.html',
  styleUrl: './capital-list.component.scss'
})
export class CapitalListComponent implements OnInit, OnDestroy {
  capitals: Capital[];
  editMode: boolean;
  mainCurrency: string = "₴";

  private unsubscribe = new Subject<void>;

  constructor(
    private readonly dialog: MatDialog,
    private readonly capitalService: CapitalService,
    private readonly popupMessageService: PopupMessageService) { }

  ngOnInit(): void {
    this.refresh();
  }

  ngOnDestroy(): void {
    this.unsubscribe.complete();
  }

  toggleEditMode(): void {
    this.editMode = !this.editMode;
  }

  openToCreateCapitalDialog(): void {
    let dialogRef = this.dialog.open(CapitalDialogComponent);

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((response) => {
        if (response) {
          this.refresh();
          this.popupMessageService.success("The capital was successful added.")
        }
      });
  }

  totalCapitalAmount(): number {
    return this.capitals?.reduce((accumulator, capital) => accumulator + capital.balance, 0) ?? 0;
  }

  removeCapital(id: number, event: MouseEvent): void {
    event.stopPropagation();
    event.preventDefault();

    this.editMode = false;
    this.capitalService
      .remove(id)
      .subscribe(() => {
        this.refresh();
        this.popupMessageService.success("The capital was successful removed.");
      });
  }

  private refresh(): void {
    this.capitalService
      .getAll()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe((response) => {
        response.forEach(c => {
          if (c.currency == 'UAH') {
            c.currency = '₴';
          }
        });

        this.capitals = response;
      });
  }
}
