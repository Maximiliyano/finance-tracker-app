import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuContentComponent } from '../home/components/menu-content/menu-content.component';
import { AccountsComponent } from './components/accounts/accounts.component';
import { IncomesComponent } from './components/incomes/incomes.component';
import { ExpensesComponent } from './components/expenses/expenses.component';
import { TransfersComponent } from './components/transfers/transfers.component';
import { GoalsComponent } from './components/goals/goals.component';

const routes: Routes = [
  {
    path: '',
    component: MenuContentComponent,
    children: [
      {
        path: 'accounts',
        component: AccountsComponent
      },
      {
        path: 'incomes',
        component: IncomesComponent
      },
      {
        path: 'expenses',
        component: ExpensesComponent
      },
      {
        path: 'transfers',
        component: TransfersComponent
      },
      {
        path: 'goals',
        component: GoalsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MenuRoutingModule { }
