import { Component } from '@angular/core';  
import { CompanyService } from '../services/company.service';
import { ErrorHandlerService} from '../services/error-handler.service';  
import { Subject } from 'rxjs';
import { Company}  from 'src/models/company'; 

@Component({  
    templateUrl: './fetchcompany.component.html'  
})  
  
export class FetchCompanyComponent {  
    public companyList: Company[];  
    dtOptions: DataTables.Settings = {};
    dtTrigger: Subject<any> = new Subject();
    public errorMessage: string = '';
  
    constructor(private _CompanyService: CompanyService, private errorHandler: ErrorHandlerService)  {  
        this.ngOnInit();  
    }  
  
    ngOnInit(){
        this.dtOptions = {
            pagingType: 'full_numbers',
            pageLength: 2
          };
              this._CompanyService.getAll().subscribe(
          (data: Company[]) => { this.companyList = data;
          this.dtTrigger.next();
          }); 

    }

    /*getCompanies() {
       
    
    });
      }*/
  
    delete(companyID) {  
        var ans = confirm("Do you want to delete company with Id: " + companyID);  
        if (ans) {  
            this._CompanyService.deleteCompany(companyID).subscribe((data) => {  
                this.ngOnInit();  
            }, error => console.error(error));
            this.errorMessage = this.errorHandler.errorMessage;
        }  
    }  
}  
