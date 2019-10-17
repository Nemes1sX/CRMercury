import { BrowserModule } from '@angular/platform-browser';
import { CompanyService } from './services/company.service'; 
import { EmployeeService} from './services/employee.service';
import { TaskService} from './services/task.service';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DataTablesModule } from 'angular-datatables';
import {DatePipe} from '@angular/common';
import { DlDateTimeDateModule, DlDateTimePickerModule } from 'angular-bootstrap-datetimepicker';
import * as $ from 'jquery';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { FetchCompanyComponent} from './fetchcompany/fetchcompany.component';
import { AddCompanyComponent} from './addcompany/addcompany.component';
import { FetchEmployeeComponent} from './fetchemployee/fetchemployee.component';
import { AddEmployeeComponent} from './addemployee/addemployee.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { AddTaskComponent } from './tasks/addtask/addtask.component';
import { FetchtaskComponent } from './tasks/fetchtask/fetchtask.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutusComponent,
    FetchCompanyComponent,
    AddCompanyComponent,
    FetchEmployeeComponent,
    AddEmployeeComponent,
    InternalServerComponent,
    NotFoundComponent,
    AddTaskComponent,
    FetchtaskComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    DataTablesModule,
    DlDateTimeDateModule,  
    DlDateTimePickerModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'aboutus', component: AboutusComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },  
      { path: 'company', component: FetchCompanyComponent },  
      { path: 'company/register', component: AddCompanyComponent },  
      { path: 'company/edit/:id', component: AddCompanyComponent },  
      { path: 'employee', component: FetchEmployeeComponent},
      { path: 'employee/register', component: AddEmployeeComponent},
      { path: 'employee/edit/:id', component: AddEmployeeComponent},
      { path: 'task', component: FetchtaskComponent},
      { path: 'task/register', component: AddTaskComponent},
      { path: 'task/edit/:id', component: AddTaskComponent},
      { path: '500', component: InternalServerComponent },
      { path: '404', component: NotFoundComponent },
      { path: '**', redirectTo: '/404' }  
    ])
  ],
  providers: [CompanyService, EmployeeService, TaskService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
