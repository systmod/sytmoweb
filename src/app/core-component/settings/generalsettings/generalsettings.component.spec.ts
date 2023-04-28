import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralsettingsComponent } from './generalsettings.component';

describe('GeneralsettingsComponent', () => {
  let component: GeneralsettingsComponent;
  let fixture: ComponentFixture<GeneralsettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeneralsettingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GeneralsettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
