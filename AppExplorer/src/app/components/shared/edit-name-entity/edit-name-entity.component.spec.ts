import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditNameEntityComponent } from './edit-name-entity.component';

describe('EditNameEntityComponent', () => {
  let component: EditNameEntityComponent;
  let fixture: ComponentFixture<EditNameEntityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditNameEntityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditNameEntityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
