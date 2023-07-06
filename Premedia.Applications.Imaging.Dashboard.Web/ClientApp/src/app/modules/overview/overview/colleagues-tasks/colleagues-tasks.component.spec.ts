import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColleaguesTasksComponent } from './colleagues-tasks.component';

describe('ColleaguesTasksComponent', () => {
  let component: ColleaguesTasksComponent;
  let fixture: ComponentFixture<ColleaguesTasksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ColleaguesTasksComponent]
    });
    fixture = TestBed.createComponent(ColleaguesTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
