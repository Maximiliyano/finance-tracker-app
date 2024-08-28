import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CapitalService } from '../../../services/capital.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Capital } from '../../../models/capital-model';

@Component({
  selector: 'app-capital-dialog',
  templateUrl: './capital-dialog.component.html',
  styleUrl: './capital-dialog.component.scss'
})
export class CapitalDialogComponent implements OnInit {
  addCapitalForm: FormGroup;

  constructor(
    private readonly capitalService: CapitalService,
    private readonly dialogRef: MatDialogRef<CapitalDialogComponent>) { }
  
  ngOnInit(): void {
    this.addCapitalForm = new FormGroup({
      Name: new FormControl('', [Validators.required])
    })
  }

  addNewCapital(): void {
    const capital: Capital = {
      id: 0,
      name: this.getFormValue('Name'),
      balance: 0,
      totalIncome: 0,
      totalExpense: 0,
      transferOut: 0,
      transferIn: 0,
      editable: false
    };
    
    this.capitalService.add(capital)
      .subscribe((x) => x, (error) => console.error(error));

    this.close();
  }

  close(): void {
    this.dialogRef.close();
  }

  getFormValue(fieldName: string): any {
    return this.addCapitalForm.get(fieldName)?.value;
  }

  hasError(controlName: string, error: string): boolean {
    return (this.addCapitalForm.get(controlName)?.hasError(error) && this.addCapitalForm.get(controlName)?.touched)!;
  }
}
