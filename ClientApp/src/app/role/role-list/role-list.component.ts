import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const ROLE_API_URL = 'api/role';

@Component({
  selector: 'app-role',
  templateUrl: './role-list.component.html'
})
export class RoleComponent {
  public roles: roleDto[];
  private base_url: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    http.get<roleDto[]>(baseUrl + ROLE_API_URL).subscribe(result => {
      this.roles = result;
    }, error => console.error(error));
  }
}

interface permissionsDto {
  permissionId: number;
  selfActionOnly: boolean;
  actionCreate: boolean;
  actionRead: boolean;
  actionUpdate: boolean;
  actionDelete: boolean;		
  actionRoleId: number;
  actionRoleName: string;
}

interface roleDto {
  roleId: number;
  title: string;
  description: string;
  permissionsDto: permissionsDto[];
}
