import { IncomeType } from "./income-type";

export interface Income {
    id: number;
    capitalId: number;
    amount: number;
    purpose: string;
    type: string;
    createdAt: Date;
}
