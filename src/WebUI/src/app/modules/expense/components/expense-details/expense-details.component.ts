import { Component, Input } from '@angular/core';
import {ExpenseResponse} from "../../models/expense-response";

@Component({
  selector: 'app-expense-details',
  templateUrl: './expense-details.component.html',
  styleUrl: './expense-details.component.scss'
})
export class ExpenseDetailsComponent {
  @Input() expense: ExpenseResponse | null;

  editMode: boolean;
}
