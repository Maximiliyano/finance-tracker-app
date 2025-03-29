import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './categories.component';
import { CategoryDetailsComponent } from './components/category-details/category-details.component';
import { categoryIdResolver } from '../../core/resolvers/category-id.resolver';
import { CategoryListComponent } from './category-list/category-list.component';

let routes: Routes = [
  {
    path: '',
    component: CategoriesComponent,
    children: [
      {
        path: '',
        component: CategoryListComponent
      },
      {
        path: ':category.id',
        component: CategoryDetailsComponent,
        resolve: { category: categoryIdResolver }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule { }
