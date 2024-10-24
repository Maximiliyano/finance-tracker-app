import { CurrencyType } from "../../../core/models/currency-type";

export interface AddCapitalRequest {
    name: string,
    balance: number,
    currency: CurrencyType
}
