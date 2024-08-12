import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { ExchangeDialogComponent } from './components/exchange-dialog/exchange-dialog.component';

@NgModule({
  declarations: [
    ExchangeDialogComponent,
    HomeComponent
  ],
  imports: [HomeRoutingModule, SharedModule]
})
export class HomeModule { }
