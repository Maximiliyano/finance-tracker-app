import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { Result } from '../models/result';
import { PopupMessageService } from '../../shared/services/popup-message.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const popupMessageService = inject(PopupMessageService);

  return next(req).pipe(
    catchError((response) => {
      const result: Result = response.error;

      if(result.title === undefined) {
        popupMessageService.error('Unexpected error happend. Connection refused.', 99999);
      }
      else {
        for(let i = 0; i < result.errors.length; i++) {
          popupMessageService.error(result.errors[i].message);
        }
      }

      return throwError(result.errors);
    })
  );
};
