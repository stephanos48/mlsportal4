import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TxqohactualsComponent } from './txqohactuals.component';

describe('TxqohactualsComponent', () => {
  let component: TxqohactualsComponent;
  let fixture: ComponentFixture<TxqohactualsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TxqohactualsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TxqohactualsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
