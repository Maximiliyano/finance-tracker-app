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

      if(error.title === undefined) {
        snackBarService.display('Unexpected error happend. Connection refused.');
      }
      else {
        for(let i = 0; i < error.errors.length; i++) {
          snackBarService.display(error.errors[i].message);
        }
      }

      return throwError(error);
    })
  );
};
