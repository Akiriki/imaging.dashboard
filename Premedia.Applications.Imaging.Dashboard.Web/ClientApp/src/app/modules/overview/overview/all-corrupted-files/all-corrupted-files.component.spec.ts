import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllCorruptedFilesComponent } from './all-corrupted-files.component';

describe('AllCorruptedFilesComponent', () => {
  let component: AllCorruptedFilesComponent;
  let fixture: ComponentFixture<AllCorruptedFilesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllCorruptedFilesComponent]
    });
    fixture = TestBed.createComponent(AllCorruptedFilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
