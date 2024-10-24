import { Category } from "../../../core/models/category-model";
import { Capital } from "../../capital/models/capital-model";

export interface Expense {
  id: number;
  categoryId: number;
  category: Category;
  capitalId: number;
  capital: Capital;
  amount: number;
  paymentDate: Date;
  purpose: string | null;
}
