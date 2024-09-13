import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject, takeUntil } from 'rxjs';
import { Capital } from '../../../menu/models/capital-model';
import { CapitalService } from '../../../menu/services/capital.service';
import { CapitalDialogComponent } from '../capital-dialog/capital-dialog.component';
import { SnackbarService } from '../../../../shared/services/snackbar.service';

@Component({
  selector: 'app-capital-list',
  templateUrl: './capital-list.component.html',
  styleUrl: './capital-list.component.scss'
})
export class CapitalListComponent implements OnInit, OnDestroy {
  capitals: Capital[];
  editMode: boolean;

  private unsubcribe = new Subject<void>;

  constructor(
    private readonly dialog: MatDialog,
    private readonly capitalService: CapitalService,
    private readonly snackBarService: SnackbarService) { }

  ngOnInit(): void {
    this.refresh();
  }

  ngOnDestroy(): void {
    this.unsubcribe.complete();
  }

  toggleEditMode(): void {
    this.editMode = !this.editMode;
  }

  openToCreateCapitalDialog(): void {
    let dialogRef = this.dialog.open(CapitalDialogComponent);

    dialogRef
      .afterClosed()
      .pipe(takeUntil(this.unsubcribe))
      .subscribe((response) => {
        if (response) {
          this.refresh();
          this.snackBarService.display("The capital was successful added.")
        }
      });
  }

  removeCapital(id: number): void {
    this.editMode = false;
    this.capitalService
      .remove(id)
      .subscribe(() => {
        this.refresh();
        this.snackBarService.display("The capital was successful removed.");
      });
  }

  private refresh(): void {
    this.capitalService
      .getAll()
      .pipe(takeUntil(this.unsubcribe))
      .subscribe((response) => {
        this.capitals = response;
      });
  }
}