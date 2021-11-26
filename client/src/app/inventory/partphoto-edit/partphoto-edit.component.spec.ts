import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartphotoEditComponent } from './partphoto-edit.component';

describe('PartphotoEditComponent', () => {
  let component: PartphotoEditComponent;
  let fixture: ComponentFixture<PartphotoEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PartphotoEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PartphotoEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
