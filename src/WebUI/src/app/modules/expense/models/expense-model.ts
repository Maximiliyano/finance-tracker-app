import { CategoryResponse } from "../../../core/models/category-response";
import {CapitalResponse} from "../../capital/models/capital-response";

export interface ExpenseResponse {
  id: number;
  categoryId: number;
  category: CategoryResponse;
  capitalId: number;
  capital: CapitalResponse;
  amount: number;
  paymentDate: Date;
  purpose: string | null;
}
