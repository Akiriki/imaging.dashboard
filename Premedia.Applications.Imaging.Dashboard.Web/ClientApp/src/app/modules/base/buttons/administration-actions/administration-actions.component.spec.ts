import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrationActionsComponent } from './administration-actions.component';

describe('AdministrationActionsComponent', () => {
  let component: AdministrationActionsComponent;
  let fixture: ComponentFixture<AdministrationActionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdministrationActionsComponent]
    });
    fixture = TestBed.createComponent(AdministrationActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
