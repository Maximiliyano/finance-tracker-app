import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn, Router } from '@angular/router';
import { CapitalService } from '../../modules/capital/services/capital.service';
import { catchError, of } from 'rxjs';
import {CapitalResponse} from "../../modules/capital/models/capital-response";

export const capitalIdResolver: ResolveFn<CapitalResponse> = (route: ActivatedRouteSnapshot) => {
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
