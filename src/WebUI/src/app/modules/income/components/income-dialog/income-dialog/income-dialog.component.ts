import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { Income } from '../../../models/income';
import { IncomeService } from '../../../services/income.service';

@Component({
  selector: 'app-income-dialog',
  templateUrl: './income-dialog.component.html',
  styleUrl: './income-dialog.component.scss'
})
export class IncomeDialogComponent implements OnInit, OnDestroy {
  addIncomeForm: FormGroup;

  private unsubcribe = new Subject<void>;

  constructor(
    private readonly incomeService: IncomeService,
    private readonly dialogRef: MatDialogRef<IncomeDialogComponent>) {
  }
  
  ngOnInit(): void {
    this.addIncomeForm = new FormGroup({
      Amount: new FormGroup('', [Validators.required]),
      Purpose: new FormGroup(''),
      Type: new FormGroup(0)
    })
  }

  ngOnDestroy(): void {
    this.unsubcribe.complete();
  }

  addNewIncome(): void {
    const request: Income = {
      amount: this.getFormValue('Amount'),
      purpose: this.getFormValue('Purpose'),
      type: this.getFormValue('type')
    }

    this.incomeService.add(request);
  }

  getFormValue(fieldName: string): any {
    return this.addIncomeForm.get(fieldName)?.value;
  }

  close(response: boolean): void {
    this.dialogRef.close(response);
  }
}
