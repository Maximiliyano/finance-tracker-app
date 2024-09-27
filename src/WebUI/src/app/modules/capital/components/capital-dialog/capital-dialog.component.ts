import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { CapitalService } from '../../../menu/services/capital.service';
import { CurrencyType } from '../../../../core/models/currency-type';
import { AddCapitalRequest } from '../../models/add-capital-request';

@Component({
  selector: 'app-capital-dialog',
  templateUrl: './capital-dialog.component.html',
  styleUrl: './capital-dialog.component.scss'
})
export class CapitalDialogComponent implements OnInit, OnDestroy {
  addCapitalForm: FormGroup;
  CurrencyType = CurrencyType;
  
  private unsubscribe = new Subject<void>;

  constructor(
    private readonly capitalService: CapitalService,
    private readonly dialogRef: MatDialogRef<CapitalDialogComponent>) { }
  
  ngOnInit(): void {
    this.addCapitalForm = new FormGroup({
      Name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(24)]),
      Balance: new FormControl('', [Validators.required, Validators.min(0)]),
      Currency: new FormControl(CurrencyType.UAH, [Validators.required])
    })
  }

  ngOnDestroy(): void {
    this.unsubscribe.complete();
  }

  addNewCapital(): void {
    const request: AddCapitalRequest = {
      name: this.getFormValue('Name'),
      balance: this.getFormValue('Balance'),
      currency: this.getFormValue('Currency')
    };
    
    this.capitalService.add(request)
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(
        () => {
          this.close(true);
        },
        () => {
          this.close(false);
        });
  }

  close(response: boolean): void {
    this.dialogRef.close(response);
  }

  getFormValue(fieldName: string): any {
    return this.addCapitalForm.get(fieldName)?.value;
  }

  hasError(controlName: string, error: string): boolean {
    return (this.addCapitalForm.get(controlName)?.hasError(error) && this.addCapitalForm.get(controlName)?.touched)!;
  }
}
