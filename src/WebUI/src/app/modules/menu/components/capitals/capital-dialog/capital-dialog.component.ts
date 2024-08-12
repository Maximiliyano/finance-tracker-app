import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Capital } from '../../../models/capital-model';
import { CapitalService } from '../../../services/capital.service';

@Component({
  selector: 'app-capital-dialog',
  templateUrl: './capital-dialog.component.html',
  styleUrl: './capital-dialog.component.scss'
})
export class CapitalDialogComponent {
  capital: Capital;

  constructor(
    private readonly capitalService: CapitalService,
    private readonly dialogRef: MatDialogRef<CapitalDialogComponent>) { }

  onCancel(): void {
    this.dialogRef.close();
  }

  addNewCapital(): void {
    this.capitalService.add(this.capital);
  }
}
