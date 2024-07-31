import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Exchange } from '../../models/exchange-model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {
  exchanges: Exchange[] | null;

  constructor(private readonly httpClient: HttpClient) { }

  ngOnInit(): void {
    this.httpClient
      .get<Exchange[]>('https://localhost:8001/api/exchanges')
      .subscribe((exchanges) => {
        this.exchanges = exchanges;
      }, (error) => console.error(error));
  }
}
