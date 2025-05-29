import { ResolveFn, Router } from '@angular/router';
import { CategoryResponse } from '../models/category-model';
import { inject } from '@angular/core';
import { CategoryService } from '../../shared/services/category.service';
import { catchError, of } from 'rxjs';

export const categoryIdResolver: ResolveFn<CategoryResponse> = (route) => {
  const categoryService = inject(CategoryService);
  const router = inject(Router);
  const id: number = route.params['category.id'];

  return categoryService
    .getById(id)
    .pipe(
      catchError(() => {
        router.navigate(['/404']);
        return of();
      }));
};
