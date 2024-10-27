import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { ExpenseRoutingModule } from './expense-routing.module';
import { ExpensesComponent } from './expenses.component';
import { ExpensesDialogComponent } from './components/expenses-dialog/expenses-dialog.component';
import { ExpenseDetailsComponent } from './components/expense-details/expense-details.component';

@NgModule({
  declarations: [
    ExpensesComponent,
    ExpensesDialogComponent,
    ExpenseDetailsComponent,
  ],
  imports: [ExpenseRoutingModule, SharedModule]
})
export class ExpenseModule { }
