import { DatePipe } from "@angular/common";

export class Task {
id: number;
CompanyId: number;
EmployeeId: number;
name: string;
taskdate: DatePipe;
description: string;
state: string;
status: boolean;
}
