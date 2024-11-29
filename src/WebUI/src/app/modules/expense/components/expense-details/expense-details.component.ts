import { Component, Input } from '@angular/core';
import { Expense } from '../../models/expense-model';

@Component({
  selector: 'app-expense-details',
  templateUrl: './expense-details.component.html',
  styleUrl: './expense-details.component.scss'
})
export class ExpenseDetailsComponent {
  @Input() expense: Expense | null;

  editMode: boolean;
}
