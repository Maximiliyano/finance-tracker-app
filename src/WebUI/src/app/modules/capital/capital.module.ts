import { CapitalRoutingModule } from './capital-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { CapitalsComponent } from './capitals.component';

@NgModule({
  declarations: [
    CapitalsComponent
  ],
  imports: [CapitalRoutingModule, SharedModule]
})
export class CapitalModule { }
