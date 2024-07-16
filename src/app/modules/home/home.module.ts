import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { MenuListComponent } from "./components/menu-list/menu-list.component";

@NgModule({
  declarations: [
    HomeComponent,
    MenuListComponent
  ],
  imports: [HomeRoutingModule, SharedModule]
})
export class HomeModule { }
