import { BrowserModule } from '@angular/platform-browser';
import { CompanyService } from './services/coservice.service'; 
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { FetchCompanyComponent} from './fetchcompany/fetchcompany.component';
import { AddCompanyComponent} from './addcompany/addcompany.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
<<<<<<< HEAD
    AboutusComponent,
    FetchCompanyComponent,
    AddCompanyComponent,
=======
    RoleComponent,
>>>>>>> 4b4364deec09789b63e3636e9dfe51fb4a6bbf93
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
<<<<<<< HEAD
      { path: '/aboutus', component: AboutusComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },  
      { path: 'companies', component: FetchCompanyComponent },  
      { path: 'register-company', component: AddCompanyComponent },  
      { path: 'company/edit/:id', component: AddCompanyComponent },  
      { path: '**', redirectTo: 'home' }  
=======
      { path: 'role', component: RoleComponent },
>>>>>>> 4b4364deec09789b63e3636e9dfe51fb4a6bbf93
    ])
  ],
  providers: [CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
