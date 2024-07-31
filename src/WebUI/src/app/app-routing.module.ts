import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

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
