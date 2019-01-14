"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var common_1 = require('@angular/common');
var laboratorio_inquiry_component_1 = require('./laboratorio-inquiry.component');
//var customer_maintenance_component_1 = require('./customer-maintenance.component');
var laboratorios_routing_module_1 = require('./laboratorios-routing.module');
var LaboratoriosModule = (function () {
    function LaboratoriosModule() {
    }
    LaboratoriosModule = __decorate([
        core_1.NgModule({
            declarations: [
                laboratorio_inquiry_component_1.LaboratorioInquiryComponent
                //customer_maintenance_component_1.CustomerMaintenanceComponent
            ],
            imports: [
                common_1.CommonModule,
                laboratorios_routing_module_1.LaboratoriosRoutingModule
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], LaboratoriosModule);
    return LaboratoriosModule;
}());
exports.LaboratoriosModule = LaboratoriosModule;
//# sourceMappingURL=customers-module.js.map
