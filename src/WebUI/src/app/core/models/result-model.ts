import { Error } from "./error-model";

export interface Result {
    title: string;
    errors: Error[];
}
