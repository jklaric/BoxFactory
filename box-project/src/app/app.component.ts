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
  searchTerm: string = '';
  filteredItems: any[] = [];

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    const apiUrl = 'http://localhost:5035/testdb';

    this.httpClient.get(apiUrl).subscribe((data: any) => {
      this.items = data;
      this.filterItems(); // Initial filtering
    });
  }

  filterItems() {
    this.filteredItems = this.items.filter((item) => {
      const searchString = this.searchTerm.toLowerCase();
      const dimensions = `${item.height}x${item.width}x${item.length}`.toLowerCase();
      const itemType = item.type.toLowerCase();
      return dimensions.includes(searchString) || itemType.includes(searchString);
    }).slice(0, 50);
  }

  addBox() {
    // Implement the logic to add a new box here.
  }

  editBox(index: number) {
    // Implement the logic to edit a box here.
  }

  deleteBox(index: number) {
    // Implement the logic to delete a box here.
  }
}

