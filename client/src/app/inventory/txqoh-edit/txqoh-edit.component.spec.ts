import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TxqohEditComponent } from './txqoh-edit.component';

describe('TxqohEditComponent', () => {
  let component: TxqohEditComponent;
  let fixture: ComponentFixture<TxqohEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TxqohEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TxqohEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
