import { Injectable, Inject } from '@angular/core';  
import { HttpClient} from '@angular/common/http';
import { Observable, of, Subject } from "rxjs";
import { map } from 'rxjs/operators';   
import { Company } from 'src/models/company';
import { throwError } from 'rxjs';
import { catchError} from 'rxjs/operators';  


@Injectable()  
export class CompanyService {  
    myAppUrl: string = "";  
  
    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {  
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
  
