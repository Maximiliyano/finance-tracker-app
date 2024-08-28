import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { SnackbarService } from '../../shared/services/snackbar.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const snackBarService = inject(SnackbarService);


  return next(req).pipe(
    catchError((response) => {
      const error = response.error;

      console.log(error);

      snackBarService.open(error.message, 'x', {

      });

      return throwError(error);
    })
  );
};
