import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./modules/home/home.module').then((x) => x.HomeModule)
  },
  {
    path: 'menu',
    loadChildren: () =>
      import('./modules/menu/menu.module').then((x) => x.MenuModule)
  },
  {
    path: 'profile',
    canActivate: [authGuard],
    loadChildren: () =>
      import('./modules/profile/profile.module').then((x) => x.ProfileModule)
  },
  {
    path: 'capitals',
    loadChildren: () =>
      import('./modules/capital/capital.module').then((x) => x.CapitalModule)
  },
  {
    path: '**',
    redirectTo: '404'
  },
  {
    path: '404',
    pathMatch: 'full',
    loadComponent: () =>
      import('./core/layout/not-found/not-found.component').then((x) => x.NotFoundComponent)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
