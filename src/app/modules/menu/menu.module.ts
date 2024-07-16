import { NgModule } from '@angular/core';
import { MenuComponent } from './menu.component';
import { AccountsComponent } from './components/accounts/accounts.component';
import { ExpensesComponent } from './components/expenses/expenses.component';
import { GoalsComponent } from './components/goals/goals.component';
import { IncomesComponent } from './components/incomes/incomes.component';
import { TransfersComponent } from './components/transfers/transfers.component';
import { MenuRoutingModule } from './menu-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { ExpensesDialogComponent } from './components/expenses/expenses-dialog/expenses-dialog.component';

@NgModule({
  declarations: [
    MenuComponent,
    AccountsComponent,
    ExpensesComponent,
    ExpensesDialogComponent,
    GoalsComponent,
    IncomesComponent,
    TransfersComponent
  ],
  imports: [MenuRoutingModule, SharedModule]
})
export class MenuModule { }
