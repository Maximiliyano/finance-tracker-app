import { Expense } from "../../modules/expense/models/expense-model";
import { CategoryType } from "./category-type";
import {Income} from "../../modules/income/models/income";

export interface Category {
  id: number;
  name: string;
  type: CategoryType;
  expenses: Expense[] | null;
  incomes: Income[] | null;
}
