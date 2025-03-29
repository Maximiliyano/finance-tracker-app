import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { Capital } from '../../models/capital-model';
import { CapitalService } from '../../services/capital.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { PopupMessageService } from '../../../../shared/services/popup-message.service';
import { UpdateCapitalRequest } from '../../models/update-capital-request';
import { ConfirmDialogService } from '../../../../shared/services/confirm-dialog.service';
import { CurrencyType } from '../../../../core/types/currency-type';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Currency } from '../../../../shared/components/currency/models/currency';
import { getCurrencies } from '../../../../shared/components/currency/functions/get-currencies.component';
import { ExchangeService } from '../../../../shared/services/exchange.service';
import { Exchange } from '../../../../core/models/exchange-model';

@Component({
  selector: 'app-capital-details',
  templateUrl: './capital-details.component.html',
  styleUrl: './capital-details.component.scss'
})
export class CapitalDetailsComponent implements OnInit, OnDestroy {
  capitalForm: FormGroup;
  formModified: boolean = false;
  capital: Capital | null;
  currencies: Currency[];
  exchanges: Exchange[];

  unsubscribe = new Subject<void>;
  currencyType = CurrencyType;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly formBuilder: FormBuilder,
    private readonly exchangeService: ExchangeService,
    private readonly capitalService: CapitalService,
    private readonly popupMessageService: PopupMessageService,
    private readonly confirmDialogService: ConfirmDialogService) {}

  ngOnInit(): void {
    this.capital = this.route.snapshot.data['capital'];

    this.capitalForm = this.formBuilder.group({
      name: [this.capital?.name, [Validators.required, Validators.maxLength(32)]],
      balance: [this.capital?.balance, [Validators.required]],
      currency: [this.capital?.currency, Validators.required]
    });

    this.currencies = getCurrencies(this.capital?.currency);

    this.exchangeService.getAll().subscribe({
      next: (response) => this.exchanges = response
    });

    this.capitalForm.valueChanges.subscribe(() => {
      this.formModified = !this.isFormEqualToModel();
    });

    this.capitalForm.get("currency")?.valueChanges.subscribe((value) => {
      const exchange = this.exchanges.find(x => x.targetCurrency === this.capital?.currency); // TODO && nationcurrency == value.currency

      if (value !== this.capital?.currency &&
          exchange
      ) {
        // TODO get exchanges and perform calculation, the best approach to separate logic of calc into separate service
        const saleAmount = (this.capital?.balance ?? 0) * exchange.sale;

        this.capitalForm.patchValue({ balance: saleAmount });
      }
      else if (this.capital?.currency !== this.capitalForm.get("balance")?.value){
        this.capitalForm.patchValue({ balance: this.capital?.balance });
      }
    })
  }

  ngOnDestroy(): void {
    this.unsubscribe.next();
    this.unsubscribe.complete();
  }

  redirectToExpensePage(capitalId: number): void {
    this.router.navigate(['/expenses'], { queryParams: { capitalId: capitalId }});
    // TODO complete
  }

  saveChanges(): void {
    if (this.capitalForm.invalid || !this.capital) {
      this.popupMessageService.error('The capital was empty.');
      return;
    }

    const capitalId = this.capital.id;
    const updatedCapital = this.capitalForm.value;

    const request: UpdateCapitalRequest = {
      name: this.capital.name == updatedCapital.name ? null : updatedCapital.name,
      balance: this.capital.balance == updatedCapital.name ? null : updatedCapital.balance,
      currency: this.capital.currency == updatedCapital.currency ? null : updatedCapital.currency
    };

    this.confirmDialogService.toggle('update capital', 'update')
      .then((confirmed) => {
        if (confirmed) {
          this.capitalService
            .update(capitalId, request)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(() => {
              this.popupMessageService.success('The capital was successfully updated.');
              this.formModified = false;
            });
        } else {
          this.cancelChanges();
        }
      });
  }

  cancelChanges(): void {
    this.capitalForm.reset(this.capital);
    this.formModified = false;
    this.popupMessageService.warning('The changes was reverted.')
  }

  remove(id: number): void {
    this.confirmDialogService.toggle('delete capital', 'delete')
      .then((confirmed) => {
        if (confirmed) {
          this.capitalService
            .delete(id)
            .pipe(takeUntil(this.unsubscribe))
            .subscribe(() => {
              this.popupMessageService.success('The capital was successfully deleted.');
              this.router.navigate(['/capitals']);
            });
        } else {
          this.popupMessageService.warning('The deletion of capital was canceled.');
        }
      });
  }

  isFormEqualToModel(): boolean {
    const capitalForm = this.capitalForm.value;

    return (
      capitalForm.name == this.capital?.name &&
      capitalForm.balance == this.capital?.balance &&
      capitalForm.currency == this.capital?.currency
    );
  }

  modelInvalidAndTouched(controlName: string): boolean | undefined {
    return this.capitalForm.get(controlName)?.invalid &&
          (this.capitalForm.get(controlName)?.dirty ||
          this.capitalForm.get(controlName)?.touched);
  }

  modelError(controlName: string, error: string): boolean {
    return (this.capitalForm.get(controlName)?.hasError(error) && this.capitalForm.get(controlName)?.touched)!;
  }
}
