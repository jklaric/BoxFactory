import { Component, Input } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-edit-box-modal',
  templateUrl: './edit-box-modal.component.html',
  styleUrls: ['./edit-box-modal.component.css']
})
export class EditBoxModalComponent {
  @Input() editedBox: any;

  constructor(private modalController: ModalController) {}

  saveChanges() {
    this.modalController.dismiss({ editedBox: this.editedBox });
  }

  dismissModal() {
    this.modalController.dismiss();
  }
}
