import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError, throwError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const snackBarService = inject(MatSnackBar);


  return next(req).pipe(
    catchError((response) => {
      const error = response.error;

      snackBarService.open(error);

      return throwError(error);
    })
  );
};
