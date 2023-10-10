import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBoxModalComponent } from './edit-box-modal.component';

describe('EditBoxModalComponent', () => {
  let component: EditBoxModalComponent;
  let fixture: ComponentFixture<EditBoxModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditBoxModalComponent]
    });
    fixture = TestBed.createComponent(EditBoxModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
