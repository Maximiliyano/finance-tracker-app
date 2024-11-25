import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { CapitalService } from '../../services/capital.service';
import { CurrencyType } from '../../../../core/models/currency-type';
import { AddCapitalRequest } from '../../models/add-capital-request';
import { PopupMessageService } from '../../../../shared/services/popup-message.service';

@Component({
  selector: 'app-capital-dialog',
  templateUrl: './capital-dialog.component.html',
  styleUrl: './capital-dialog.component.scss'
})
export class CapitalDialogComponent implements OnInit, OnDestroy {
  addCapitalForm: FormGroup;

  currency = CurrencyType;

  private unsubscribe = new Subject<void>;

  constructor(
    private readonly capitalService: CapitalService,
    private readonly popupMessageService: PopupMessageService,
    private readonly dialogRef: MatDialogRef<CapitalDialogComponent>) { }

  ngOnInit(): void {
    this.addCapitalForm = new FormGroup({
      Name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(24)]),
      Balance: new FormControl(0, [Validators.required, Validators.min(0)]),
      Currency: new FormControl(CurrencyType.UAH, [Validators.required])
    });
  }

  ngOnDestroy(): void {
    this.unsubscribe.complete();
  }

  addNewCapital(): void {
    if (this.addCapitalForm.invalid) {
      this.popupMessageService.error('The capital form is invalid.');
      return;
    }

    const request: AddCapitalRequest = {
      name: this.addCapitalForm.value.Name,
      balance: this.addCapitalForm.value.Balance,
      currency: this.addCapitalForm.value.Currency
    };

    this.capitalService.add(request)
      .pipe(takeUntil(this.unsubscribe))
      .subscribe({
        next: () => {
          this.close(true);
          this.popupMessageService.success("The capital was successful added.");
        },
        error: () => this.close(false)
      });
  }

  close(response: boolean): void {
    this.dialogRef.close(response);
  }

  hasError(controlName: string, error: string): boolean {
    return (this.addCapitalForm.get(controlName)?.hasError(error) && this.addCapitalForm.get(controlName)?.touched)!;
  }
}
