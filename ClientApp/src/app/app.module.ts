import { BrowserModule } from '@angular/platform-browser';
import { CompanyService } from './services/company.service'; 
import { EmployeeService} from './services/employee.service';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { FetchCompanyComponent} from './fetchcompany/fetchcompany.component';
import { AddCompanyComponent} from './addcompany/addcompany.component';
import { FetchEmployeeComponent} from './fetchemployee/fetchemployee.component';
import { AddEmployeeComponent} from './addemployee/addemployee.component';


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
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
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
      { path: '**', redirectTo: 'home' }  
    ])
  ],
  providers: [CompanyService, EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
