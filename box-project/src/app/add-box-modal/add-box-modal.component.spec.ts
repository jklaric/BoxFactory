import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBoxModalComponent } from './add-box-modal.component';

describe('AddBoxModalComponent', () => {
  let component: AddBoxModalComponent;
  let fixture: ComponentFixture<AddBoxModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddBoxModalComponent]
    });
    fixture = TestBed.createComponent(AddBoxModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
