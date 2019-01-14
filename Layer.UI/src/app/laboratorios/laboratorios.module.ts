import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LaboratorioInquiryComponent } from './laboratorio-inquiry.component';
//import { CustomerMaintenanceComponent } from './customer-maintenance.component';
import { LaboratoriosRoutingModule } from './laboratorios-routing.module';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';


@NgModule({
    declarations: [
        LaboratorioInquiryComponent
        //CustomerMaintenanceComponent,    
    ],
    imports: [
        CommonModule,
        LaboratoriosRoutingModule,
        FormsModule,
        SharedModule
    ]

})
export class LaboratoriosModule { }
