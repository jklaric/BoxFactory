import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { AddBoxModalComponent } from './add-box-modal/add-box-modal.component';
import { EditBoxModalComponent } from './edit-box-modal/edit-box-modal.component';
import { BoxDetailsModalComponent } from './box-details-modal/box-details-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    AddBoxModalComponent,
    EditBoxModalComponent,
    BoxDetailsModalComponent
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(),
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
