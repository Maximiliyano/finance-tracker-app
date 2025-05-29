import { NgModule } from '@angular/core';
import { IncomeRoutingModule } from './income-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { IncomeDialogComponent } from './components/income-dialog/income-dialog/income-dialog.component';
import { IncomesComponent } from './incomes.component';

@NgModule({
  declarations: [
    IncomesComponent,
    IncomeDialogComponent
  ],
  imports: [IncomeRoutingModule, SharedModule]
})
export class IncomeModule { }
