import { Component, OnInit } from '@angular/core';
import { Subject} from 'rxjs';
import { ErrorHandlerService} from '../../services/error-handler.service';
import { EmployeeService} from '../../services/employee.service';
import { Employee } from 'src/models/employee';
import { CompanyService} from '../../services/company.service';
import { Company } from 'src/models/company';
import {TaskService} from '../../services/task.service';
import { Task } from 'src/models/task';

@Component({
  selector: 'app-fetchtask',
  templateUrl: './fetchtask.component.html',
  styleUrls: ['./fetchtask.component.css']
})
export class FetchtaskComponent implements OnInit {

  public taskList: Task[];
  public errorMessage: string = '';


  constructor(private errorHandler: ErrorHandlerService, private taskService: TaskService) { 
    this.ngOnInit();
  }

  ngOnInit() {
    
        this.taskService.getTasks().subscribe(
    (data: Task[]) =>  this.taskList = data
    ); 
  }

  delete(id) {
    const ans = confirm('Do you want to delete employee with Id: ' + id);
    if (ans) {
      this.taskService.deleteTask(id).subscribe(() => {
        this.ngOnInit();
      }, error => console.error(error));
      this.errorMessage = this.errorHandler.errorMessage;
    }
  }

}
