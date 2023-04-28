import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaproveedoresComponent } from './listaproveedores.component';

describe('ListaproveedoresComponent', () => {
  let component: ListaproveedoresComponent;
  let fixture: ComponentFixture<ListaproveedoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaproveedoresComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaproveedoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
