import {CapitalResponse} from "../../capital/models/capital-response";
import {CategoryResponse} from "../../../core/models/category-model";

export interface ExpenseResponse {
  id: number;
  amount: number;
  paymentDate: Date;
  capital: CapitalResponse;
  category: CategoryResponse;
  purpose: string | null;
}
