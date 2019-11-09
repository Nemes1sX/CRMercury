import { Injectable, Inject } from '@angular/core';
import  {HttpClient} from '@angular/common/http';
import { Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import { Task } from 'src/models/task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  myAppUrl = '';


  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getTasks() {
    return this._http.get(this.myAppUrl + 'api/Task/Index').pipe(map(
      response => {
        return response;
      }));
  }

  getTaskById(id: number) {
    return this._http.get(this.myAppUrl + 'api/Task/Details/' + id)
      .pipe(map(
        response => {
          return response;
        }));
  }

  saveTask(task: Task) {
    return this._http.post(this.myAppUrl + 'api/Task/Create', task)
      .pipe(map(
        response => {
          return response;
        }));
  }

  updateTask(task: Task) {
    return this._http.put(this.myAppUrl + 'api/Task/Edit', task)
      .pipe(map(
        response => {
          return response;
        }));
  }

  deleteTask(id: number) {
    return this._http.delete(this.myAppUrl + 'api/Task/Delete/' + id)
      .pipe(map(
        response => {
          return response;
        }));
      }      
  
}
