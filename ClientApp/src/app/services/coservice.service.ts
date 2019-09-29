import { Injectable, Inject } from '@angular/core';  
import { Http, Response } from '@angular/http';  
import { Observable } from 'rxjs/observable';   
import { Router } from '@angular/router';  
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
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    }  
  
    getCompanyId(id: number) {  
        return this._http.get(this.myAppUrl + "api/Company/Details/" + id)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler)  
    }  
  
    saveCompany(company) {  
        return this._http.post(this.myAppUrl + 'api/Company/Create', company)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler)  
    }  
    updateCompany(company) {  
        return this._http.put(this.myAppUrl + 'api/Company/Edit', company)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    }  
  
    deleteCompany(id) {  
        return this._http.delete(this.myAppUrl + "api/Company/Delete/" + id)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    }  
    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    } 
}   
  
