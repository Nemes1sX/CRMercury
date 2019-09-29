import { Component, OnInit} from '@angular/core';  
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';  
import { Http, Headers } from '@angular/http';  
import { FetchCompanyComponent } from '../fetchcompany/fetchcompany.component';  
import { Router, ActivatedRoute } from '@angular/router';  
import {CompanyService} from '../services/coservice.service';  
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
            employeeId: 0,  
            name: ['', [Validators.required]],  
            gender: ['', [Validators.required]],  
            department: ['', [Validators.required]],  
            city: ['', [Validators.required]]  
        })  
    }  
  
    ngOnInit() {  
  
  
        if (this.companyId > 0) {  
            this.title = "Edit";  
            this._companyService.getCompanyId(this.companyId)  
                .subscribe(resp => this.companyForm.setValue(resp)  
                , error => this.errorMessage = error);  
        }  
  
    }  
  
    save() {  
  
        if (!this.companyForm.valid) {  
            return;  
        }  
  
        if (this.title == "Create") {  
            this._companyService.saveCompany(this.companyForm.value)  
                .subscribe((data) => {  
                    this._router.navigate(['/fetch-employee']);  
                }, error => this.errorMessage = error)  
        }  
        else if (this.title == "Edit") {  
            this._companyService.updateCompany(this.companyForm.value)  
                .subscribe((data) => {  
                    this._router.navigate(['/fetch-employee']);  
                }, error => this.errorMessage = error)  
        }  
    }  
  
    cancel() {  
        this._router.navigate(['/fetch-employee']);  
    }  
  
    get name() { return this.companyForm.get('name'); }  
    get ceoname() { return this.companyForm.get('ceoname'); }  
    get phone() { return this.companyForm.get('phone'); }  
    get website() { return this.companyForm.get('website'); }  
    get email() { return this.companyForm.get('email'); }  
    get status() {return this.companyForm.get('status'); }
}

  