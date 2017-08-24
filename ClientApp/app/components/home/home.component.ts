import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { DataSource } from "@angular/cdk";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/of';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    displayedColumns = [
        'name',
        'observable',
        'apiFirst',
        'ciCdSupport',
        'tested',
        'wellDesignedDeveloped',
        'measured',
        'secured',
        'ecoSystemMember',
        'multiTenantSupport',
        'scalable',
        'resilient',
        'knowledge',
        'mastery',
        'devEcoSys',
        'wellSeparated'
    ];
    public services: Service[]
    public servicesDataSource: ServicesDataSource | null
    
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Services').subscribe(result => {
            this.services = result.json() as Service[];
            this.servicesDataSource = new ServicesDataSource(this.services);
        }, error => console.error(error));
    }
}

interface Service {
    id: number,
    name: String,
    observable: number,
    apiFirst: number,
    ciCdSupport: number,
    tested: number,
    wellDesignedDeveloped: number,
    measured: number,
    secured: number,
    ecoSystemMember: number,
    multiTenantSupport: number,
    scalable: number,
    resilient: number,
    knowledge: number,
    mastery: number,
    devEcoSys: number,
    wellSeparated: number,
    updated: Date
}

export class ServicesDataSource extends DataSource<any> {
    constructor(public services: Service[]) {
      super();
    }
  
    /** Connect function called by the table to retrieve one stream containing the data to render. */
    connect(): Observable<Service[]> {  
      return Observable.of(this.services);
    }
  
    disconnect() {}
  }