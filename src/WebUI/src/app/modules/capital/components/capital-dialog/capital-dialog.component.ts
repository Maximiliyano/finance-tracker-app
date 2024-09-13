import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { Capital } from '../../../menu/models/capital-model';
import { CapitalService } from '../../../menu/services/capital.service';

@Component({
  selector: 'app-capital-dialog',
  templateUrl: './capital-dialog.component.html',
  styleUrl: './capital-dialog.component.scss'
})
export class CapitalDialogComponent implements OnInit, OnDestroy {
  addCapitalForm: FormGroup;
  
  private unsubcribe = new Subject<void>;

  constructor(
    private readonly capitalService: CapitalService,
    private readonly dialogRef: MatDialogRef<CapitalDialogComponent>) { }
  
  ngOnInit(): void {
    this.addCapitalForm = new FormGroup({
      Name: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(24)]),
      Balance: new FormControl('', [Validators.min(0)])
    })
  }

  ngOnDestroy(): void {
    this.unsubcribe.complete();
  }

  addNewCapital(): void {
    const capital: Capital = {
      id: 0,
      name: this.getFormValue('Name'),
      balance: this.getFormValue('Balance'),
      totalIncome: 0,
      totalExpense: 0,
      transferOut: 0,
      transferIn: 0,
      editable: false
    };
    
    this.capitalService.add(capital)
      .pipe(takeUntil(this.unsubcribe))
      .subscribe(
        () => {
          this.close(true);
        },
        () => {
          this.close(false);
        });
  }

  close(response: boolean): void {
    this.dialogRef.close(response);
  }

  getFormValue(fieldName: string): any {
    return this.addCapitalForm.get(fieldName)?.value;
  }

  hasError(controlName: string, error: string): boolean {
    return (this.addCapitalForm.get(controlName)?.hasError(error) && this.addCapitalForm.get(controlName)?.touched)!;
  }
}
