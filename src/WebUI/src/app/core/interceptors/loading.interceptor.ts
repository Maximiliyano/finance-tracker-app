import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoadingService } from '../../shared/services/loading.service';
import { finalize } from 'rxjs';
import { OverlayService } from '../../shared/services/overlay.service';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingService = inject(LoadingService);
  const overlayService = inject(OverlayService);
  
  const overlayRef = overlayService.create();

  loadingService.show();

  return next(req).pipe(
    finalize(() => {
      overlayService.close(overlayRef);
      loadingService.hide();
    })
  );
};
