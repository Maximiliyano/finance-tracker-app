import { CapitalResponse } from "../../capital/models/capital-response";

export interface ExpenseResponse {
  id: number;
  amount: number;
  paymentDate: Date;
  capital: CapitalResponse;
  category: CategoryResponse;
  purpose: string | null;
}

export interface CategoryResponse {
  id: number;
  name: string;
  totalExpense: number;
}
