import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { AccountsComponent } from './components/accounts/accounts.component';
import { ExpensesComponent } from './components/expenses/expenses.component';
import { GoalsComponent } from './components/goals/goals.component';
import { IncomesComponent } from './components/incomes/incomes.component';
import { TransfersComponent } from './components/transfers/transfers.component';
import { ExpensesDialogComponent } from './components/expenses/expenses-dialog/expenses-dialog.component';
import { MenuSelectorComponent } from './components/menu-selector/menu-selector.component';

@NgModule({
  declarations: [
    HomeComponent,
    AccountsComponent,
    ExpensesComponent,
    GoalsComponent,
    IncomesComponent,
    TransfersComponent,
    ExpensesDialogComponent,
    MenuSelectorComponent
  ],
  imports: [HomeRoutingModule, SharedModule]
})
export class HomeModule { }
