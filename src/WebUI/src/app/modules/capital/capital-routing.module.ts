import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CapitalDetailsComponent } from './components/capital-details/capital-details.component';
import { CapitalsComponent } from './capitals.component';
import { CapitalListComponent } from './components/capital-list/capital-list.component';
import { capitalIdResolver } from '../../core/resolvers/capital-id.resolver';

const routes: Routes = [
  {
    path: '',
    component: CapitalsComponent,
    children: [
      {
        path: '',
        component: CapitalListComponent
      },
      {
        path: ':capital.id',
        component: CapitalDetailsComponent,
        resolve: { capital: capitalIdResolver }
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CapitalRoutingModule { }
