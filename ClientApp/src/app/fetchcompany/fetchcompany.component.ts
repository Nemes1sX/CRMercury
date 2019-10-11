import { Component } from '@angular/core';  
import { CompanyService } from '../services/company.service';
import { ErrorHandlerService} from '../services/error-handler.service';  
import { Company}  from 'src/models/company'; 

@Component({  
    templateUrl: './fetchcompany.component.html'  
})  
  
export class FetchCompanyComponent {  
    public companyList: Company[];  
    public errorMessage: string = '';
  
    constructor(private _CompanyService: CompanyService, private errorHandler: ErrorHandlerService)  {  
        this.getCompanies();  
    }  
  
    getCompanies() {
        this._CompanyService.getAll().subscribe(
          (data: Company[]) => this.companyList = data
        );
      }
  
    delete(companyID) {  
        var ans = confirm("Do you want to delete company with Id: " + companyID);  
        if (ans) {  
            this._CompanyService.deleteCompany(companyID).subscribe((data) => {  
                this.getCompanies();  
            }, error => console.error(error));
            this.errorMessage = this.errorHandler.errorMessage;
        }  
    }  
}  
