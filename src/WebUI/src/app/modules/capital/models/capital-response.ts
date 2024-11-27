export interface CapitalResponse {
  id: number;
  name: string;
  balance: number;
  currency: string;
  includeInTotal: boolean;
  totalIncome: number;
  totalExpense: number;
  totalTransferIn: number;
  totalTransferOut: number;
}
