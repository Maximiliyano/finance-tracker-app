import { Error } from "./error";

export interface Result {
    title: string;
    errors: Error[];
}
