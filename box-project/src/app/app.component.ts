import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'box-project';
  items = [
    {
      name: 'Item 1',
      description: 'Description of Item 1',
      price: 10.99,
      imageUrl: 'https://example.com/item1.jpg',
    },
    {
      name: 'Item 2',
      description: 'Description of Item 2',
      price: 19.99,
      imageUrl: 'https://example.com/item2.jpg',
    },
  ];
}
