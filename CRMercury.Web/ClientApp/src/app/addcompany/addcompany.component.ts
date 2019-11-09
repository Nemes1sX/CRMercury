import { Component, OnInit} from '@angular/core';  
import { FormBuilder, FormGroup, Validators} from '@angular/forms';  
import { Router, ActivatedRoute } from '@angular/router';  
import {CompanyService} from '../services/company.service'; 
import {ErrorHandlerService} from '../services/error-handler.service';
import {Company} from 'src/models/company'; 
@Component({  
  templateUrl: './addcompany.component.html',   
})  
export class AddCompanyComponent implements OnInit {  
     
    companyForm: FormGroup;  
    title: string = "Create";  
    id: number;  
    errorMessage: string = '';  
  
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,  
        private _companyService: CompanyService, private errorHandler: ErrorHandlerService, private _router: Router) {  
        if (this._avRoute.snapshot.params["id"]) {  
            this.id = this._avRoute.snapshot.params["id"];  
        }  
  
        this.companyForm = this._fb.group({  
            id: 0,  
            name: ['', [Validators.required]],  
            ceoname: ['', [Validators.required]],  
            website: ['', [Validators.required]],  
            phone: ['', [Validators.required]],  
            email: ['', [Validators.required]],  
            status: ['', [Validators.required]]  
        })  
    }  
  
    ngOnInit() {  
  
  
        if (this.id > 0) {
            this.title = 'Edit';
            this._companyService.getCompanyId(this.id)
              .subscribe((response: Company) => {
                this.companyForm.setValue(response);
              }, error => console.error(error));
              this.errorMessage = this.errorHandler.errorMessage;
          }  
  
    }  
  
    save() {  
  
        if (!this.companyForm.valid) {  
            return;  
        }  
  
        if (this.title == "Create") {  
            this._companyService.saveCompany(this.companyForm.value)  
                .subscribe(() => {  
                    this._router.navigate(['/company']);  
                },  error => console.error(error));
                this.errorMessage = this.errorHandler.errorMessage;
        }  
        else if (this.title == "Edit") {  
            this._companyService.updateCompany(this.companyForm.value)  
                .subscribe(() => {  
                    this._router.navigate(['/company']);  
                }, error => console.error(error));  
                this.errorMessage = this.errorHandler.errorMessage;
        }  
    }  
  
    cancel() {  
        this._router.navigate(['/companies']);  
    }  
  
    get name() { return this.companyForm.get('name'); }  
    get ceoname() { return this.companyForm.get('ceoname'); }  
    get phone() { return this.companyForm.get('phone'); }  
    get website() { return this.companyForm.get('website'); }  
    get email() { return this.companyForm.get('email'); }  
    get status() {return this.companyForm.get('status'); }
}

  