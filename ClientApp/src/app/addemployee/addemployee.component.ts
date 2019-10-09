import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../services/employee.service';
import { Employee } from 'src/models/employee';

@Component({
  selector: 'app-add-employee',
  templateUrl: './addemployee.component.html',
  styleUrls: ['./addemployee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  employeeForm: FormGroup;
  title = 'Create';
  id: number;
  errorMessage: any;
  

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _employeeService: EmployeeService, private _router: Router) {
    if (this._avRoute.snapshot.params['id']) {
      this.id = this._avRoute.snapshot.params['id'];
    }

    this.employeeForm = this._fb.group({
      id: 0,
      fullname: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      status: ['', [Validators.required]]
    })
  }

  ngOnInit() {
    

    if (this.id > 0) {
      this.title = 'Edit';
      this._employeeService.getEmployeeById(this.id)
        .subscribe((response: Employee) => {
          this.employeeForm.setValue(response);
        }, error => console.error(error));
    }
  }

  save() {

    if (!this.employeeForm.valid) {
      return;
    }

    if (this.title === 'Create') {
      this._employeeService.saveEmployee(this.employeeForm.value)
        .subscribe(() => {
          this._router.navigate(['/employee']);
        }, error => console.error(error));
    } else if (this.title === 'Edit') {
      this._employeeService.updateEmployee(this.employeeForm.value)
        .subscribe(() => {
          this._router.navigate(['/employee']);
        }, error => console.error(error));
    }
  }

  cancel() {
    this._router.navigate(['/employee']);
  }

  get fullname() { return this.employeeForm.get('fullname'); }
  get email() { return this.employeeForm.get('email'); }
  get password() { return this.employeeForm.get('password'); }
  get status() { return this.employeeForm.get('status'); }
}
