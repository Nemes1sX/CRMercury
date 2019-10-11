import { Component } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { ErrorHandlerService} from '../services/error-handler.service';
import { Employee } from 'src/models/employee';

@Component({
  selector: 'app-fetch-employee',
  templateUrl: './fetchemployee.component.html',
  styleUrls: ['./fetchemployee.component.css']
})
export class FetchEmployeeComponent {

  public empList: Employee[];
  public errorMessage: string = '';


  constructor(private _employeeService: EmployeeService,  private errorHandler: ErrorHandlerService) {
    this.getEmployees();
  }

  getEmployees() {
    this._employeeService.getEmployees().subscribe(
      (data: Employee[]) => this.empList = data
    ), error => console.error(error);
    this.errorMessage = this.errorHandler.errorMessage;
  }

  delete(employeeID) {
    const ans = confirm('Do you want to delete employee with Id: ' + employeeID);
    if (ans) {
      this._employeeService.deleteEmployee(employeeID).subscribe(() => {
        this.getEmployees();
      }, error => console.error(error));
      this.errorMessage = this.errorHandler.errorMessage;
    }
  }
}
