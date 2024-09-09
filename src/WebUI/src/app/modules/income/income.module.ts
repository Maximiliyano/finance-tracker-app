import { NgModule } from '@angular/core';
import { IncomeRoutingModule } from './income-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { IncomeDialogComponent } from './components/income-dialog/income-dialog/income-dialog.component';
import { IncomeComponent } from './income/income.component';

@NgModule({
  declarations: [
    IncomeComponent,
    IncomeDialogComponent
  ],
  imports: [IncomeRoutingModule, SharedModule]
})
export class IncomeModule { }
