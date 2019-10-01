import { Injectable, Inject } from '@angular/core';  
import { Http, Response } from '@angular/http';
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';  
import { Router } from '@angular/router';  
import { Company } from 'src/models/company';
import 'rxjs/add/operator/map';  
import 'rxjs/add/operator/catch';  
import 'rxjs/add/observable/throw'; 

@Injectable()  
export class CompanyService {  
    myAppUrl: string = "";  
  
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {  
        this.myAppUrl = baseUrl;  
    }  
  
    getAll() {  
        return this._http.get(this.myAppUrl + 'api/Company/Index')  
        .pipe(map(
            response => {
              return response;
            }));
    }  
  
    getCompanyId(id: number) {  
        return this._http.get(this.myAppUrl + "api/Company/Details/" + id)  
        .pipe(map(
            response => {
              return response;
            })); 
    }  
  
    saveCompany(company) {  
        return this._http.post(this.myAppUrl + 'api/Company/Create', company)  
        .pipe(map(
            response => {
              return response;
            }));
    }  
    updateCompany(company) {  
        return this._http.put(this.myAppUrl + 'api/Company/Edit', company)  
        .pipe(map(
            response => {
              return response;
            }));
    }  
  
    deleteCompany(id: number) {  
        return this._http.delete(this.myAppUrl + "api/Company/Delete/" + id)  
        .pipe(map(
            response => {
              return response;
            })); 
    }  
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    } 
}   
  
