import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TxqohCreateComponent } from './txqoh-create.component';

describe('TxqohCreateComponent', () => {
  let component: TxqohCreateComponent;
  let fixture: ComponentFixture<TxqohCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TxqohCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TxqohCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
