import {CategoryType} from "../types/category-type";

export interface CategoryResponse {
  id: number;
  name: string;
  type: CategoryType;

  totalExpenses: number;
  totalExpensesPercent: string;
}
