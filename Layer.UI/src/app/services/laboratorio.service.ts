import { Laboratorio } from '../entities/laboratorio.entity';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Headers, RequestOptions } from '@angular/http';
import { HttpService } from './http.service';
import { SessionService } from './session.service';


@Injectable()
export class LaboratorioService {

    constructor(private httpService: HttpService, private sessionService: SessionService) { }

    public getLaboratorios(laboratorio: Laboratorio): Observable<any> {

        let url = this.sessionService.apiServer + "laboratorios/getlaboratorios";
        return this.httpService.httpPost(laboratorio, url);

    }

    //public getCustomer(customer: Customer): Observable<any> {

    //    let url = this.sessionService.apiServer + "customers/getcustomer";
    //    return this.httpService.httpPost(customer, url);

    //}

    //public updateCustomer(customer: Customer): Observable<any> {

    //    let url = this.sessionService.apiServer + "customers/updatecustomer";
    //    return this.httpService.httpPost(customer, url);

    //}


}
