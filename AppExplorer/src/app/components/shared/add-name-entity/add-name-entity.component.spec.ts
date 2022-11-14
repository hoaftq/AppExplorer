import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNameEntityComponent } from './add-name-entity.component';

describe('AddNameEntityComponent', () => {
  let component: AddNameEntityComponent;
  let fixture: ComponentFixture<AddNameEntityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddNameEntityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNameEntityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
