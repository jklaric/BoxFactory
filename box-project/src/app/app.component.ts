import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'box-project';
  items: any[] = [];

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    const apiUrl = 'http://localhost:5035/testdb';

    this.httpClient.get(apiUrl).subscribe((data: any) => {
      this.items = data;
    });
  }
}

