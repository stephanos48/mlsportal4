import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TxqohComponent } from './txqoh.component';

describe('TxqohComponent', () => {
  let component: TxqohComponent;
  let fixture: ComponentFixture<TxqohComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TxqohComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TxqohComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
