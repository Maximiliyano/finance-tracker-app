import { Component, OnDestroy, OnInit } from '@angular/core';
import { CategoryResponse } from '../../../../core/models/category-model';
import { Subject } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrl: './category-details.component.scss'
})
export class CategoryDetailsComponent implements OnInit, OnDestroy {
  category: CategoryResponse | null;

  $unsubscribe = new Subject<void>();

  constructor(private readonly route: ActivatedRoute) {}


  ngOnInit(): void {
    this.category = this.route.snapshot.data['category'];
  }

  ngOnDestroy(): void {
    this.$unsubscribe.next();
    this.$unsubscribe.complete();
  }
}
