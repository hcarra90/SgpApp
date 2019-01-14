import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import { CustomerMaintenanceComponent } from './customer-maintenance.component';
import { LaboratorioInquiryComponent } from './laboratorio-inquiry.component';
import { AuthorizationGuard } from "../authorization-guard";

const laboratoriosRoutes: Routes = [
    { path: '', component: LaboratorioInquiryComponent },
    { path: 'laboratorio-inquiry', component: LaboratorioInquiryComponent, canActivate: [AuthorizationGuard] }
    //{ path: 'customer-maintenance', component: CustomerMaintenanceComponent, canActivate: [AuthorizationGuard] }
]

@NgModule({
    imports: [
        RouterModule.forChild(laboratoriosRoutes)
    ],
    exports: [RouterModule]
})
export class LaboratoriosRoutingModule { }
