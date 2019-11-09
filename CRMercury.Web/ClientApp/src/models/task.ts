import { DatePipe } from "@angular/common";
import {  Company } from "src/models/company"; 
import {  Employee } from "src/models/employee"; 


export class Task {
id: number;
companyId: number;
company: any;
employeeId: number;
employee: any;
name: string;
taskdate: Date;
description: string;
state: string;
status: boolean;
}
