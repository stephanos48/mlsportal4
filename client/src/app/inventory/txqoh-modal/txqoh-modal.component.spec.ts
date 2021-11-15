import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TxqohModalComponent } from './txqoh-modal.component';

describe('TxqohModalComponent', () => {
  let component: TxqohModalComponent;
  let fixture: ComponentFixture<TxqohModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TxqohModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TxqohModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
