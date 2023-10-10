import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoxDetailsModalComponent } from './box-details-modal.component';

describe('BoxDetailsModalComponent', () => {
  let component: BoxDetailsModalComponent;
  let fixture: ComponentFixture<BoxDetailsModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BoxDetailsModalComponent]
    });
    fixture = TestBed.createComponent(BoxDetailsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
