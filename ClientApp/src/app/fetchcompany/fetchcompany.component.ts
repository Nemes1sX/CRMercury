import { Component, Inject } from '@angular/core';  
import { Http, Headers } from '@angular/http';  
import { Router, ActivatedRoute } from '@angular/router';  
import { CompanyService } from '../../services/coservice.service'  
  
@Component({  
    templateUrl: './fetchemployee.component.html'  
})  
  
export class FetchCompanyComponent {  
    public empList: EmployeeData[];  
  
    constructor(public http: Http, private _router: Router, private _employeeService: CompanyService) {  
        this.getAll();  
    }  
  
    getAll() {  
        this._CompanyService.getEmployees().subscribe(  
            data => this.empList = data  
        )  
    }  
  
    delete(companyID) {  
        var ans = confirm("Do you want to delete company with Id: " + companyID);  
        if (ans) {  
            this._employeeService.deleteEmployee(companyID).subscribe((data) => {  
                this.getAll();  
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