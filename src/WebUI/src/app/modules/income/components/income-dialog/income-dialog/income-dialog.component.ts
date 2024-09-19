import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { Income } from '../../../models/income';
import { IncomeService } from '../../../services/income.service';
import { IncomeType } from '../../../models/income-type';

@Component({
  selector: 'app-income-dialog',
  templateUrl: './income-dialog.component.html',
  styleUrl: './income-dialog.component.scss'
})
export class IncomeDialogComponent implements OnInit, OnDestroy {
  addIncomeForm: FormGroup;
  incomeType = IncomeType;

  private unsubscribe = new Subject<void>;

  constructor(
    private readonly incomeService: IncomeService,
    private readonly dialogRef: MatDialogRef<IncomeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private readonly data: number) {
  }
  
  ngOnInit(): void {
    this.addIncomeForm = new FormGroup({
      Amount: new FormControl(0, [Validators.required]),
      Purpose: new FormControl('', [Validators.required]),
      Type: new FormControl(this.incomeType.Salary, [Validators.required])
    })
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

  addNewIncome(): void {
    const request = {
      capitalId: this.data,
      amount: this.getFormValue('Amount'),
      purpose: this.getFormValue('Purpose'),
      type: this.getFormValue('Type')
    };

    this.incomeService.add(request).subscribe(() =>
      this.close(true));
  }

  getFormValue(fieldName: string): any {
    return this.addIncomeForm.get(fieldName)?.value;
  }

  close(response: boolean): void {
    this.dialogRef.close(response);
  }
}
