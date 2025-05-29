import { CurrencyType } from "../../../../core/types/currency-type";

export function stringToCurrencyEnum(currency: string): CurrencyType | null {
  const enumKey = currency.toUpperCase() as keyof typeof CurrencyType;

  if (CurrencyType[enumKey]) {
    return CurrencyType[enumKey];
  }

  return null;
}
