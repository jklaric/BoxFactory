import { Component, Input } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-box-details-modal',
  templateUrl: './box-details-modal.component.html',
  styleUrls: ['./box-details-modal.component.css']
})
export class BoxDetailsModalComponent {
  @Input() box: any;

  constructor(private modalController: ModalController) {}

  dismissModal() {
    this.modalController.dismiss();
  }
}
