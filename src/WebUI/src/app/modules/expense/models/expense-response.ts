import {CategoryResponse} from "../../../core/models/category-model";

export interface ExpenseResponse {
  id: number;
  amount: number;
  paymentDate: Date;
  capitalId: number;
  category: CategoryResponse;
  purpose: string | null;
}
