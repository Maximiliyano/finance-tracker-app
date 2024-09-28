import { Component, OnDestroy, OnInit } from '@angular/core';
import { Capital } from '../../../menu/models/capital-model';
import { CapitalService } from '../../../menu/services/capital.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { PopupMessageService } from '../../../../shared/services/popup-message.service';
import { UpdateCapitalRequest } from '../../models/update-capital-request';
import { ConfirmDialogService } from '../../../../shared/services/confirm-dialog.service';
import { CurrencyType } from '../../../../core/models/currency-type';
import { NgModel, ValidationErrors } from '@angular/forms';

@Component({
  selector: 'app-capital-details',
  templateUrl: './capital-details.component.html',
  styleUrl: './capital-details.component.scss'
})
export class CapitalDetailsComponent implements OnInit, OnDestroy {
  isModified: boolean;
  capital: Capital | null;
  backupCapital: any;
  unsubscribe = new Subject<void>;
  currencyType = CurrencyType;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly capitalService: CapitalService,
    private readonly popupMessageService: PopupMessageService,
    private readonly confirmDialogService: ConfirmDialogService) {}

  ngOnInit(): void {
    this.capital = this.route.snapshot.data['capital'];

    this.backupOriginalCapital();
  }

  ngOnDestroy(): void {
    this.unsubscribe.complete();
  }

  onInputChange(): void {
    this.isModified = JSON.stringify(this.capital) !== JSON.stringify(this.backupCapital);
  }

  saveChanges(): void { // TODO add confirm dialog
    if (!this.capital) {
      this.popupMessageService.error('The capital was empty.');
      return;
    }

    const request: UpdateCapitalRequest = {
      name: this.capital.name,
      balance: this.capital.balance,
      currency: this.capital.currency
    };

    this.capitalService
      .update(this.capital.id, request)
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(() => {
        this.popupMessageService.success('The capital was successfull updated.');
        this.backupOriginalCapital();
        this.isModified = false;
      }, (error) => this.popupMessageService.error(error));
  }

  cancelChanges(): void {
    this.revertOriginalCapital();
    this.isModified = false;
    this.popupMessageService.warning('The changes was reverted.')
  }

  delete(id: number): void { // TODO add confirm dialog
    this.confirmDialogService.toggle('Delete', 'delete').then((value) => {
      if (value) {
        this.capitalService
          .remove(id)
          .pipe(takeUntil(this.unsubscribe))
          .subscribe(() => {
            this.popupMessageService.success('The capital was successfull deleted.');
            this.router.navigate(['/capitals']);
          }, (error) => this.popupMessageService.error(error));
      } else {
        this.popupMessageService.warning('The deletetion of capital was canceled.');
      }
    });
  }

  backupOriginalCapital(): void {
    this.backupCapital = {... this.capital };
  }

  revertOriginalCapital(): void {
    this.capital = {... this.backupCapital };
  }

  getCurrencyValues(): string[] {
    return Object.keys(this.currencyType)
      .filter((key) => isNaN(Number(key)) && key !== "None" && key !== this.capital?.currency);
  }

  modelInvalidAndTouched(model: NgModel): boolean | null {
    return model.invalid && model.touched;
  }

  modelError(model: NgModel, errorName: string): any {
    return model.errors?.[errorName];
  }
}
