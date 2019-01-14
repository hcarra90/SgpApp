import { Component, OnInit, EventEmitter, Output, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DataGridColumn, DataGridButton, DataGridEventInformation } from '../shared/datagrid/datagrid.core';
import { DataGrid } from '../shared/datagrid/datagrid.component';
import { AlertService } from '../services/alert.service';
import { LaboratorioService } from '../services/laboratorio.service';
import { AlertBoxComponent } from '../shared/alertbox.component';
import { Laboratorio } from '../entities/laboratorio.entity';
import { TransactionalInformation } from '../entities/transactionalinformation.entity';

@Component({
    templateUrl: './laboratorio-inquiry.component.html'
})

export class LaboratorioInquiryComponent implements OnInit {

    @ViewChild(DataGrid) datagrid: DataGrid;

    public title: string = 'Laboratotio Inquiry';
    public laboratorios: Laboratorio[];
    public columns = [];

    public alerts: Array<string> = [];
    public messageBox: string;

    public totalRows: number;
    public currentPageNumber: number = 1;
    public totalPages: number;
    public pageSize: number;
    public laboratorioName: string;
    public laboratorioId: number;
    private estado: string;
    private sortDirection: string;
    private sortExpression: string;

    public autoFilter: Boolean;
    public delaySearch: Boolean;
    public runningSearch: Boolean;

    constructor(private alertService: AlertService, private laboratorioService: LaboratorioService, private router: Router) {

        this.currentPageNumber = 1;
        this.autoFilter = false;
        this.totalPages = 0;
        this.totalRows = 0;
        this.pageSize = 15;
        this.sortDirection = "ASC";
        this.sortExpression = "Name";

    }

    public ngOnInit() {

        this.columns.push(new DataGridColumn('Nombre', 'Laboratorio', '[{"width": "20%" , "disableSorting": false}]'));
        this.columns.push(new DataGridColumn('Estado', 'Estado', '[{"width": "30%" , "hyperLink": true, "disableSorting": false}]'));
        this.executeSearch();

    }

    private executeSearch(): void {

        if (this.runningSearch == true) return;

        let miliseconds = 500;

        if (this.delaySearch == false) {
            miliseconds = 0;
        }

        this.runningSearch = true;

        setTimeout(() => {

            let laboratorio = new Laboratorio();
            laboratorio.Id = this.laboratorioId
            laboratorio.Nombre = this.laboratorioName;
            laboratorio.Estado = this.estado;
            laboratorio.pageSize = this.pageSize;
            laboratorio.sortDirection = this.sortDirection;
            laboratorio.sortExpression = this.sortExpression;
            laboratorio.currentPageNumber = this.currentPageNumber;

            this.laboratorioService.getLaboratorios(laboratorio)
                .subscribe(
                response => this.getLaboratoriosOnSuccess(response),
                response => this.getLaboratoriosOnError(response));

        }, miliseconds)

    }


    private getLaboratoriosOnSuccess(response: Laboratorio): void {

        let transactionalInformation = new TransactionalInformation();
        transactionalInformation.currentPageNumber = this.currentPageNumber;
        transactionalInformation.pageSize = this.pageSize;
        transactionalInformation.totalPages = response.totalPages;
        transactionalInformation.totalRows = response.totalRows;
        transactionalInformation.sortDirection = this.sortDirection;
        transactionalInformation.sortExpression = this.sortExpression;

        this.laboratorios = response.laboratorios;

        this.datagrid.databind(transactionalInformation);

        this.alertService.renderSuccessMessage(response.returnMessage);
        this.messageBox = this.alertService.returnFormattedMessage();
        this.alerts = this.alertService.returnAlerts();

        this.runningSearch = false;

    }

    private getLaboratoriosOnError(response): void {

        this.alertService.renderErrorMessage(response.returnMessage);
        this.messageBox = this.alertService.returnFormattedMessage();
        this.alerts = this.alertService.returnAlerts();

        this.runningSearch = false;

    }

    public datagridEvent(event) {
        let datagridEvent: DataGridEventInformation = event.value;

        if (datagridEvent.EventType == "PagingEvent") {
            this.pagingLaboratorios(datagridEvent.CurrentPageNumber);
        }

        else if (datagridEvent.EventType == "PageSizeChanged") {
            this.pageSizeChanged(datagridEvent.PageSize);
        }

        else if (datagridEvent.EventType == "ItemSelected") {
            this.selectedLaboratorio(datagridEvent.ItemSelected);
        }

        else if (datagridEvent.EventType == "Sorting") {
            this.sortLaboratorios(datagridEvent.SortDirection, datagridEvent.SortExpression);
        }

    }


    private selectedLaboratorio(itemSelected: number) {

        let rowSelected = itemSelected;
        let row = this.laboratorios[rowSelected];
        let laboratorioID = row.Id;

        this.router.navigate(['/laboratorio/laboratorio-maintenance', { id: laboratorioID }]);

    }

    private sortLaboratorios(sortDirection: string, sortExpression: string) {
        this.sortDirection = sortDirection;
        this.sortExpression = sortExpression;
        this.currentPageNumber = 1;
        this.delaySearch = false;
        this.executeSearch();
    }

    private pagingLaboratorios(currentPageNumber: number) {
        this.currentPageNumber = currentPageNumber;
        this.delaySearch = false;
        this.executeSearch();
    }

    private pageSizeChanged(pageSize: number) {
        this.pageSize = pageSize;
        this.currentPageNumber = 1;
        this.delaySearch = false;
        this.executeSearch();
    }

    public reset(): void {
        this.laboratorioId = 0;
        this.laboratorioName = "";
        this.currentPageNumber = 1;
        this.delaySearch = false;
        this.executeSearch();
    }

    public search(): void {
        this.currentPageNumber = 1;
        this.delaySearch = false;
        this.executeSearch();
    }

    public companyNameChanged(newValue): void {

        if (this.autoFilter == false) return;
        if (newValue == "") return;

        this.laboratorioName = newValue;
        this.currentPageNumber = 1;
        this.delaySearch = true;

        setTimeout(() => {
            this.executeSearch();
        }, 500)

    }

    public estadoChanged(newValue): void {

        if (this.autoFilter == false) return;
        if (newValue == "") return;

        this.estado = newValue;
        this.currentPageNumber = 1;
        this.delaySearch = true;

        setTimeout(() => {
            this.executeSearch();
        }, 500)

    }


}
