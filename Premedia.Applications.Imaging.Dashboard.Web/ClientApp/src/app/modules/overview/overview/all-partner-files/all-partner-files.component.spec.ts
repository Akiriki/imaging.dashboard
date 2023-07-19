import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllPartnerFilesComponent } from './all-partner-files.component';

describe('AllPartnerFilesComponent', () => {
  let component: AllPartnerFilesComponent;
  let fixture: ComponentFixture<AllPartnerFilesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllPartnerFilesComponent]
    });
    fixture = TestBed.createComponent(AllPartnerFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
