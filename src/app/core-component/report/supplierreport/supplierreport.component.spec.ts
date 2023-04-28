import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierreportComponent } from './supplierreport.component';

describe('SupplierreportComponent', () => {
  let component: SupplierreportComponent;
  let fixture: ComponentFixture<SupplierreportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SupplierreportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SupplierreportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
