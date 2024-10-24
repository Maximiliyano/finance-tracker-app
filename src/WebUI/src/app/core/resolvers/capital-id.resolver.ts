import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn, Router } from '@angular/router';
import { CapitalService } from '../../modules/capital/services/capital.service';
import { catchError, of } from 'rxjs';
import { Capital } from '../../modules/capital/models/capital-model';

export const capitalIdResolver: ResolveFn<Capital> = (route: ActivatedRouteSnapshot) => {
  const capitalService = inject(CapitalService);
  const router = inject(Router);
  const capitalId: number = route.params['capital.id'];

  return capitalService
    .getById(capitalId)
    .pipe(
      catchError(() => {
        router.navigate(['/404']);
        return of();
      }));
};
