import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-income-dialog',
  standalone: true,
  imports: [],
  templateUrl: './income-dialog.component.html',
  styleUrl: './income-dialog.component.scss'
})
export class IncomeDialogComponent implements OnInit {
  constructor(private readonly dialogRef: MatDialogRef<IncomeDialogComponent>) {
  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
