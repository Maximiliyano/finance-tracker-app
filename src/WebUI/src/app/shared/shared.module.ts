import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from './angular-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OverlayComponent } from './components/overlay/overlay.component';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { ExchangeDialogComponent } from './components/exchange-dialog/exchange-dialog.component';
import { CurrencyComponent } from './components/currency/currency.component';

@NgModule({
  declarations: [
    OverlayComponent,
    ConfirmDialogComponent,
    ExchangeDialogComponent,
    CurrencyComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    CommonModule,
    AngularMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    CurrencyComponent
  ]
})
export class SharedModule { }
