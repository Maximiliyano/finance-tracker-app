import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { CategoryRoutingModule } from './category-routing.module';
import { CategoriesComponent } from './categories.component';
import { CategoryDetailsComponent } from './components/category-details/category-details.component';
import { CategoryListComponent } from './category-list/category-list.component';

@NgModule({
  declarations: [
    CategoriesComponent,
    CategoryDetailsComponent,
    CategoryListComponent
  ],
  imports: [ CategoryRoutingModule, SharedModule ]
})
export class CategoryModule { }
