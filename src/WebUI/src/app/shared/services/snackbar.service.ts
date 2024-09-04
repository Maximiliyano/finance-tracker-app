import { Injectable, NgZone } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig, MatSnackBarRef, TextOnlySnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {
  private readonly defaultDuration = 3000;
  private readonly defaultConfig: MatSnackBarConfig = {
    duration: this.defaultDuration
  };

  constructor(private readonly snackBar: MatSnackBar,
              private readonly zone: NgZone) { }

  display(message: string): void {
    this.show(message);
  }

  private show(message: string, customConfig: MatSnackBarConfig = {}): Promise<MatSnackBarRef<any>> {
    return new Promise(resolve => {
      this.zone.run(() => {
        const finalConfig: MatSnackBarConfig = {
          ...this.defaultConfig,
          ...customConfig,
          panelClass: [...(customConfig.panelClass || [])]
        };
  
        const snackBarRef = this.snackBar.open(message, 'x', finalConfig);
      
        snackBarRef.afterDismissed().subscribe(() => resolve(snackBarRef));
      })
    })
  }
}