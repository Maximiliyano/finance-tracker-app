import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { ExchangeDialogComponent } from './components/exchange-dialog/exchange-dialog.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';

@NgModule({
  declarations: [
    ExchangeDialogComponent,
    UserProfileComponent,
    HomeComponent
  ],
  imports: [HomeRoutingModule, SharedModule]
})
export class HomeModule { }
