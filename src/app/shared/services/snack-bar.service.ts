import { MatSnackBarModule } from '@angular/material/snack-bar';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {

  constructor(
    private readonly snackBarModule: MatSnackBarModule) { }

  open(): void {
  }
}
