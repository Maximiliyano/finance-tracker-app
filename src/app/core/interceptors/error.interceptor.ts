import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { SnackBarService } from '../../shared/services/snack-bar.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const snackBarService = inject(SnackBarService);

  return next(req).pipe(
    catchError((response) => {
      const error = response.error;

      snackBarService.open();

      return throwError(error);
    })
  );
};
