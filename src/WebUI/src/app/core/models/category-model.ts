import { Expense } from "../../modules/expense/models/expense";
import { CategoryType } from "./category-type";

export interface Category {
  id: number;
  name: string;
  type: CategoryType;
  expenses: Expense[] | null;
}
