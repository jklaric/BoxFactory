import { Component, Input, EventEmitter, Output } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-box-modal',
  template: `
    <ion-header>
      <ion-toolbar>
        <ion-title>
          Add New Box
        </ion-title>
        <ion-buttons slot="end">
          <ion-button (click)="dismissModal()">
            Close
          </ion-button>
        </ion-buttons>
      </ion-toolbar>
    </ion-header>

    <ion-content>
      <ion-item>
        <ion-label position="floating">Height</ion-label>
        <ion-input type="number" [(ngModel)]="newBox.height" required></ion-input>
      </ion-item>
      <ion-item>
        <ion-label position="floating">Width</ion-label>
        <ion-input type="number" [(ngModel)]="newBox.width" required></ion-input>
      </ion-item>
      <ion-item>
        <ion-label position="floating">Length</ion-label>
        <ion-input type="number" [(ngModel)]="newBox.length" required></ion-input>
      </ion-item>
      <ion-item>
        <ion-label position="floating">Type</ion-label>
        <ion-input type="text" [(ngModel)]="newBox.type" required></ion-input>
      </ion-item>
      <ion-button expand="full" (click)="addBox()">Add</ion-button>
    </ion-content>
  `
})
export class AddBoxModalComponent {
  @Output() boxAdded: EventEmitter<any> = new EventEmitter();
  newBox: any = {};
  
  constructor(private modalController: ModalController, private httpClient: HttpClient) {}

  addBox() {
    const newBox = {
      height: this.newBox.height,
      width: this.newBox.width,
      length: this.newBox.length,
      type: this.newBox.type,
    };

    
    if (
      !newBox.height ||
      !newBox.width ||
      !newBox.length ||
      !newBox.type
    ) {
      alert('Please fill in all fields.');
      return;
    }

    
    const apiUrl = 'http://localhost:5035/api/boxes/create';

    this.httpClient.post(apiUrl, newBox).subscribe((response: any) => {
      console.log('Response from server:', response);
      this.boxAdded.emit(response);
    });
    this.dismissModal();
    window.location.reload();
  }

  dismissModal() {
    this.modalController.dismiss();
  }
}
