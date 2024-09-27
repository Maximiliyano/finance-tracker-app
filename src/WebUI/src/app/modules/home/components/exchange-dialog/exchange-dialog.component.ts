import { Component, Inject } from '@angular/core';
import { Exchange } from '../../../../core/models/exchange-model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-exchange-dialog',
  templateUrl: './exchange-dialog.component.html',
  styleUrl: './exchange-dialog.component.scss'
})
export class ExchangeDialogComponent {

  constructor(
    @Inject(MAT_DIALOG_DATA) public exchanges: Exchange[] | null,
    private readonly dialogRef: MatDialogRef<ExchangeDialogComponent>) { }

  close() {
    this.dialogRef.close();
  }
}
