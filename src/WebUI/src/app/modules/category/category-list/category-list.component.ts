import { Component, OnDestroy, OnInit } from '@angular/core';
import { CategoryService } from '../../../shared/services/category.service';
import { CategoryResponse } from '../../../core/models/category-model';
import { Subject, takeUntil } from 'rxjs';
import { CategoryType } from '../../../core/types/category-type';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.scss'
})
export class CategoryListComponent implements OnInit, OnDestroy {
  categories: CategoryResponse[];
  CategoryType: CategoryType;

  private $unsubscribe = new Subject<void>();

  constructor(private readonly categoryService: CategoryService) {}

  ngOnInit(): void {
    this.categoryService
      .getAll()
      .pipe(takeUntil(this.$unsubscribe))
      .subscribe({
        next: (response) => this.categories = response
      });
  }
  ngOnDestroy(): void {
    this.$unsubscribe.next();
    this.$unsubscribe.complete();
  }

}
