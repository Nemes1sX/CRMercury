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
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';


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
      { path: '500', component: InternalServerComponent },
      { path: '404', component: NotFoundComponent },
      { path: '**', redirectTo: '/404' }  
    ])
  ],
  providers: [CompanyService, EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
