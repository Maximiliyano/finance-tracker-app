import { Component, Input, OnInit } from '@angular/core';
import { Capital } from '../../../menu/models/capital-model';
import { CapitalService } from '../../../menu/services/capital.service';
import { ActivatedRoute } from '@angular/router';
import { IncomeDialogComponent } from '../../../income/components/income-dialog/income-dialog/income-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-capital-details',
  templateUrl: './capital-details.component.html',
  styleUrl: './capital-details.component.scss'
})
export class CapitalDetailsComponent implements OnInit {
  capital: Capital;

  constructor(
    private readonly dialog: MatDialog,
    private readonly route: ActivatedRoute,
    private readonly capitalService: CapitalService) {}

  ngOnInit(): void {
    let id = this.route.snapshot.params['capital.id'];
    
    this.capitalService
      .getById(id)
      .subscribe((response) => this.capital = response);
  }

  addIncome(): void {
    let dialogRef = this.dialog.open(IncomeDialogComponent);
  }

  addExpense(): void {
    
  }
}
