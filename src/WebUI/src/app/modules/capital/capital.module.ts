import { NgModule } from '@angular/core';
import { CapitalRoutingModule } from './capital-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { CapitalDetailsComponent } from './components/capital-details/capital-details.component';
import { CapitalsComponent } from './capitals.component';
import { CapitalDialogComponent } from './components/capital-dialog/capital-dialog.component';
import { CapitalListComponent } from './components/capital-list/capital-list.component';

@NgModule({
  declarations: [
    CapitalsComponent,
    CapitalListComponent,
    CapitalDetailsComponent,
    CapitalDialogComponent
  ],
  imports: [CapitalRoutingModule, SharedModule]
})
export class CapitalModule { }
