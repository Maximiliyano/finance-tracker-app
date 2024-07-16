import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Expense } from '../expenses.component';

@Component({
  selector: 'app-expenses-dialog',
  templateUrl: './expenses-dialog.component.html',
  styleUrl: './expenses-dialog.component.scss'
})
export class ExpensesDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<ExpensesDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Expense) {}

  onCancel(): void {
    this.dialogRef.close();
  }
}
