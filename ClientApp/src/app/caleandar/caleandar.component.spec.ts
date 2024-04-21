import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaleandarComponent } from './caleandar.component';

describe('CaleandarComponent', () => {
  let component: CaleandarComponent;
  let fixture: ComponentFixture<CaleandarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CaleandarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CaleandarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
