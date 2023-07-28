import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlphaChannelComponent } from './alpha-channel.component';

describe('AlphaChannelComponent', () => {
  let component: AlphaChannelComponent;
  let fixture: ComponentFixture<AlphaChannelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlphaChannelComponent]
    });
    fixture = TestBed.createComponent(AlphaChannelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
