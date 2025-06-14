import {Injectable} from "@angular/core";
import {environment} from "../../../environments/environment.development";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {CategoryResponse} from "../../core/models/category-model";
import { CategoryType } from "../../core/types/category-type";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private baseApiUrl = environment.apiUrl + '/api/categories';

  constructor(private readonly http: HttpClient) { }

  getAll(type: CategoryType | null = null): Observable<CategoryResponse[]> {
    let params = new HttpParams();

    if (type != null) {
      params = params.set('type', type);
    }

    return this.http.get<CategoryResponse[]>(this.baseApiUrl, { params });
  }

  getById(id: number): Observable<CategoryResponse> {
    return this.http.get<CategoryResponse>(`${this.baseApiUrl}/${id}`);
  }
}
