import { Component, OnInit} from '@angular/core';  
import { FormBuilder, FormGroup, Validators} from '@angular/forms';  
import { Router, ActivatedRoute } from '@angular/router';  
import {CompanyService} from '../services/company.service'; 
import {Company} from 'src/models/company'; 
@Component({  
  templateUrl: './addcompany.component.html',   
})  
export class AddCompanyComponent implements OnInit {  
     
    companyForm: FormGroup;  
    title: string = "Create";  
    companyId: number;  
    errorMessage: any;  
  
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,  
        private _companyService: CompanyService, private _router: Router) {  
        if (this._avRoute.snapshot.params["id"]) {  
            this.companyId = this._avRoute.snapshot.params["id"];  
        }  
  
        this.companyForm = this._fb.group({  
            companyId: 0,  
            name: ['', [Validators.required]],  
            ceoname: ['', [Validators.required]],  
            website: ['', [Validators.required]],  
            phone: ['', [Validators.required]],  
            email: ['', [Validators.required]],  
            status: ['', [Validators.required]]  
        })  
    }  
  
    ngOnInit() {  
  
  
        if (this.companyId > 0) {
            this.title = 'Edit';
            this._companyService.getCompanyId(this.companyId)
              .subscribe((response: Company) => {
                this.companyForm.setValue(response);
              }, error => console.error(error));
          }  
  
    }  
  
    save() {  
  
        if (!this.companyForm.valid) {  
            return;  
        }  
  
        if (this.title == "Create") {  
            this._companyService.saveCompany(this.companyForm.value)  
                .subscribe(() => {  
                    this._router.navigate(['/companies']);  
                },  error => console.error(error));
        }  
        else if (this.title == "Edit") {  
            this._companyService.updateCompany(this.companyForm.value)  
                .subscribe(() => {  
                    this._router.navigate(['/companies']);  
                }, error => console.error(error));  
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

  