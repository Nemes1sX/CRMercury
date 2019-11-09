
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router} from '@angular/router';
import { ErrorHandlerService} from '../../services/error-handler.service';
import { EmployeeService} from '../../services/employee.service';
import { Employee } from 'src/models/employee';
import { CompanyService} from '../../services/company.service';
import { Company } from 'src/models/company';
import {TaskService} from '../../services/task.service';
import {Task} from 'src/models/task';

@Component({
  selector: 'app-addtask',
  templateUrl: './addtask.component.html',
  styleUrls: ['./addtask.component.css']
})
export class AddTaskComponent implements OnInit {

  taskForm: FormGroup;
  title = 'Create';
  public empList: Employee[];
  public companyList: Company[];
  public errorMessage: string = '';
  id: number;

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute, 
    private _employeeService: EmployeeService,  private errorHandler: ErrorHandlerService, private companyService: CompanyService,
    private taskService: TaskService, private _router: Router) 
    {
      if (this._avRoute.snapshot.params['id']) {
        this.id = this._avRoute.snapshot.params['id'];
      }
     

     this.taskForm = this._fb.group({
      id: 0,
      name: ['', [Validators.required]],
      companyId: ['', [Validators.required]],
      employeeId: ['', [Validators.required]],
      taskdate: ['', [Validators.required]],
      description: ['', [Validators.required]],
      state: ['', [Validators.required]],
      status: ['', [Validators.required]]
    })
    this.getCompanies();
    this.getEmployees();
  }

  ngOnInit() {

    
    if (this.id > 0) {
      this.title = 'Edit';
      this.taskService.getTaskById(this.id)
        .subscribe((response: Task) => {
          delete response.company; 
          delete response.employee;
          response.taskdate = new Date(response.taskdate);
          this.taskForm.setValue(response);
        }, error => console.error(error));
        this.errorMessage = this.errorHandler.errorMessage;

    }

  }

  save() {

    if (!this.taskForm.valid) {
      return;
    }

    if (this.title === 'Create') {
      this.taskService.saveTask(this.taskForm.value)
        .subscribe(() => {
          this._router.navigate(['/task']);
        }, error => console.error(error));
        this.errorMessage = this.errorHandler.errorMessage;
    } else if (this.title === 'Edit') {
      this.taskService.updateTask(this.taskForm.value)
        .subscribe(() => {
          this._router.navigate(['/task']);
        }, error => console.error(error));
        this.errorMessage = this.errorHandler.errorMessage;
    }
  }


  getEmployees(){
    this._employeeService.getEmployees().subscribe(
      (data: Employee[]) => this.empList = data
    )

  } 
  getCompanies(){
    this.companyService.getAll().subscribe(
      (data: Company[]) => this.companyList = data
    )
  }

 /* get name() { return this.taskForm.get('fullname'); }
  get taskdate() { return  this.taskForm.get('taskdate'); }
  get description() { return this.taskForm.get('description'); }
  get companyId() { return this.taskForm.get('companyId'); }
  get employeeId() { return this.taskForm.get('employeeId'); }
  get state() { return this.taskForm.get('state'); }
  get status() { return this.taskForm.get('status'); }*/

}
