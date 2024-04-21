import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EachDaySheduleComponent } from './each-day-shedule.component';

describe('EachDaySheduleComponent', () => {
  let component: EachDaySheduleComponent;
  let fixture: ComponentFixture<EachDaySheduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EachDaySheduleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EachDaySheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
