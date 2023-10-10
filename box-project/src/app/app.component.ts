import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ModalController } from '@ionic/angular';
import { AddBoxModalComponent } from './add-box-modal/add-box-modal.component';
import { EditBoxModalComponent } from './edit-box-modal/edit-box-modal.component';
import { BoxDetailsModalComponent } from './box-details-modal/box-details-modal.component';

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

  constructor(private httpClient: HttpClient, private modalController: ModalController) {}

  ngOnInit() {
    const apiUrl = 'http://localhost:5035/api/boxes';

    this.httpClient.get(apiUrl).subscribe((data: any) => {
      this.items = data;
      this.filterItems(); 
    });
  }
  

  filterItems() {
    this.filteredItems = this.items.filter((item) => {
      const searchString = this.searchTerm.toLowerCase();
      const dimensions = `${item.height}x${item.width}x${item.length}`.toLowerCase();
      const itemType = item.type.toLowerCase();
      return dimensions.includes(searchString) || itemType.includes(searchString);
    });
  }


  editBox(index: number) {
    const editedBox = this.items[index];

   
    if (
      !editedBox.height ||
      !editedBox.width ||
      !editedBox.length ||
      !editedBox.type
    ) {
      alert('Please fill in all fields.');
      return;
    }

    
    const apiUrl = `http://localhost:5035/api/boxes/update/${this.items.at(index).boxID}`;

    this.httpClient.put(apiUrl, editedBox).subscribe((response: any) => {
      this.items[index] = response;
      window.location.reload();
    });
  }

  async openEditBoxModal(boxToEdit: any, index: number) {
    const modal = await this.modalController.create({
      component: EditBoxModalComponent,
      componentProps: {
        editedBox: boxToEdit
      }
    });
  
    modal.onDidDismiss().then((data) => {
      if (data.data && data.data.editedBox) {
        const editedBox = data.data.editedBox;
        if (
          !editedBox.height ||
          !editedBox.width ||
          !editedBox.length ||
          !editedBox.type
        ) {
          alert('Please fill in all fields.');
          return;
        }

      const apiUrl = `http://localhost:5035/api/boxes/update/${editedBox.boxID}`;

      this.httpClient.put(apiUrl, editedBox).subscribe((response: any) => {
      this.items[index] = response;
    });

      window.location.reload();
      }
    });
  
    await modal.present();
  }

  deleteBox(index: number) {
    const apiUrl = `http://localhost:5035/api/boxes/delete/${this.items.at(index).boxID}`;

    this.httpClient.delete(apiUrl).subscribe();

    window.location.reload();
  }

  async toggleAddForm() {
    const modal = await this.modalController.create({
      component: AddBoxModalComponent, 
      componentProps: {}
    });

    modal.onDidDismiss().then((data) => {
      if (data.data) {
        this.items.push(data.data);
      }
    });

    await modal.present();
      this.filterItems(); 
  }

  async openBoxDetailsModal(box: any) {
    const modal = await this.modalController.create({
      component: BoxDetailsModalComponent,
      componentProps: {
        box: box
      }
    });

    await modal.present();
  }

}

