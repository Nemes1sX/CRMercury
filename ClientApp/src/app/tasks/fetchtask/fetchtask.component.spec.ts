import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchtaskComponent } from './fetchtask.component';

describe('FetchtaskComponent', () => {
  let component: FetchtaskComponent;
  let fixture: ComponentFixture<FetchtaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FetchtaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchtaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
