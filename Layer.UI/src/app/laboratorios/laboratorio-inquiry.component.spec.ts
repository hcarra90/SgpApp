import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LaboratorioInquiryComponent } from './laboratorio-inquiry.component';

describe('LaboratorioInquiryComponent', () => {
    let component: LaboratorioInquiryComponent;
    let fixture: ComponentFixture<LaboratorioInquiryComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [LaboratorioInquiryComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(LaboratorioInquiryComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should be created', () => {
        expect(component).toBeTruthy();
    });
});
