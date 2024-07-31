export interface Account {
  id: number;
  name: string;
  balance: number;
  totalIncome: number;
  totalExpense: number;
  transferOut: number;
  transferIn: number;
  editable: boolean;
}
