import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnnualHolidaysComponent } from './annual-holidays.component';

describe('AnnualHolidaysComponent', () => {
  let component: AnnualHolidaysComponent;
  let fixture: ComponentFixture<AnnualHolidaysComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AnnualHolidaysComponent]
    });
    fixture = TestBed.createComponent(AnnualHolidaysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
