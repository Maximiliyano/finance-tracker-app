import { Injectable, NgZone } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {
  constructor(private readonly snackBar: MatSnackBar,
              private readonly zone: NgZone) { }

  success(message: string): void {
    this.show(message, { panelClass: ['snackbar-container', 'success'] });
  }

  warning(message: string): void {
    this.show(message, { panelClass: ['snackbar-container']});
  }

  private show(message: string, customConfig: MatSnackBarConfig = {}): void {
    const customClasses = coerceToArray(customConfig.panelClass)
      .filter((v) => typeof v === 'string') as string[];

    this.zone.run(() => {
      this.snackBar.open(
        message,
        'x',
        { ...customConfig, panelClass: ['snackbar-container', ...customClasses]}
      );
    })
  }
}
