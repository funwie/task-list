import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Task, TaskList } from './types';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators/';
import { AuthorizeService } from '../api-authorization/authorize.service';

@Injectable()
export class ApiService {

  public taskLists: TaskList[] = [];
  public taskList: TaskList;
  public tasks: Task[] = [];
  public task: Task;

  private authToken: string;;

  constructor(private http: HttpClient, private authService: AuthorizeService, @Inject('BASE_URL') private baseUrl: string) {
    this.getAuthToken();
  }

  loadLists(): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasklists`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.get<TaskList[]>(requestUrl, { headers })
      .pipe(map((data) => {
        this.taskLists = data;
        return true;
      }));
  }

  loadTaskForList(listId: string): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasklists/${listId}/tasks`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.get<Task[]>(requestUrl, { headers })
      .pipe(map((data) => {
      this.tasks = data;
      return true;
    }));
  }

  createList(list: { title: string; }): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasklists`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.post(requestUrl, list, { headers })
      .pipe(map((data: TaskList) => {
        this.taskList = data;
        return true;
      }));
  }

  createTask(createTask: { description: string; start: Date; end: Date; taskListId: string; }): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasks`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.post(requestUrl, createTask, { headers })
      .pipe(map((data: Task) => {
        this.task = data;
        return true;
      }));
  }

  updateTask(task: { id: string, description: string; start: string; end: string; }): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasks/${task.id}`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.put(requestUrl, task, { headers })
      .pipe(map((data: Task) => {
        this.task = data;
        return true;
      }));
  }

  completeTask(taskId: string): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasks/${taskId}/complete`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.patch(requestUrl, {}, { headers })
      .pipe(map((data: Task) => {
        this.task = data;
        return true;
      }));

  }

  startTask(taskId: string): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasks/${taskId}/start`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.patch(requestUrl, {}, { headers })
      .pipe(map((data: Task) => {
        this.task = data;
        return true;
      }));
  }

  openTask(taskId: string): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasks/${taskId}/open`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.patch(requestUrl, {},  { headers })
      .pipe(map((data: Task) => {
        this.task = data;
        return true;
      }));

  }

  removeTask(taskId: string): Observable<boolean> {
    const requestUrl = `${this.baseUrl}api/tasks/${taskId}/`;
    const headers = new HttpHeaders().set("Content-Type", "application/json").set('Authorization', `Bearer ${this.authToken}`);

    return this.http.delete(requestUrl, { headers })
      .pipe(map((result) => {
        return true;
      }));

  }

  private getAuthToken() {
    this.authService.getAccessToken().subscribe(token => {
      if (token !== undefined) {
        this.authToken = token;
      }
    }, error => console.log('Failed to load tasks'));
  };

}
