import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { ExpenseRoutingModule } from './expense-routing.module';

@NgModule({
  declarations: [],
  imports: [ExpenseRoutingModule, SharedModule]
})
export class ExpenseModule { }
