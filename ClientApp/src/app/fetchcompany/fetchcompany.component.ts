import { Component, Inject } from '@angular/core';  
import { Http, Headers } from '@angular/http';  
import { Router, ActivatedRoute } from '@angular/router';  
import { CompanyService } from '../services/coservice.service'  
import { Company}  from 'src/models/company'; 

@Component({  
    templateUrl: './fetchcompany.component.html'  
})  
  
export class FetchCompanyComponent {  
    public companyList: Company[];  
  
    constructor(private _CompanyService: CompanyService) {  
        this.getCompanies();  
    }  
  
    getCompanies() {
        this._CompanyService.getAll().subscribe(
          data => this.companyList 
        );
      }
  
    delete(companyID) {  
        var ans = confirm("Do you want to delete company with Id: " + companyID);  
        if (ans) {  
            this._CompanyService.deleteCompany(companyID).subscribe((data) => {  
                this.getCompanies();  
            }, error => console.error(error))  
        }  
    }  
}  
  
interface CompanyData {  
    companyId: number;  
    name: string;  
    ceoname: string;
    email: string;  
    phone: string;  
    website: string;  
    status: boolean;
}