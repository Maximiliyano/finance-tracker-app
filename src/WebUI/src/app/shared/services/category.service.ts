import {Injectable} from "@angular/core";
import {environment} from "../../../environments/environment.development";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {Category} from "../../core/models/category-model";
import { CategoryType } from "../../core/models/category-type";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private baseApiUrl = environment.apiUrl + '/api/categories';

  constructor(private readonly http: HttpClient) { }

  getAll(type: CategoryType | null = null): Observable<Category[]> {
    let params = new HttpParams();

    if (type != null) {
      params = params.set('type', type);
    }

    return this.http.get<Category[]>(this.baseApiUrl, { params });
  }
}
