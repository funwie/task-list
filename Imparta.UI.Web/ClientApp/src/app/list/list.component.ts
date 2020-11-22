import { Component, Input, OnInit } from '@angular/core';
import { TaskList, Task } from './../types';
import { ApiService } from './../api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html'
})

export class ListComponent implements OnInit {

  public taskLists: TaskList[];
  public tasks: Task[];

  public taskList: TaskList;
  public task: Task;

  public createList = {
    title: ''
  };

  errorMessage: string = '';
  activeListId: string = '';

  constructor(private apiService: ApiService) {
    this.taskLists = this.apiService.taskLists;
    this.tasks = this.apiService.tasks;
  }

  ngOnInit() {
    this.loadLists();
  }

  public loadTasks(event, taskList: TaskList) {
    this.errorMessage = '';
    this.apiService.loadTaskForList(taskList.id).subscribe(success => {
      if (success) {
        this.tasks = this.apiService.tasks;
        this.activeListId = taskList.id;
      }
    }, error => this.errorMessage = 'Failed to load tasks');
  }

  public onNewList() {
    this.errorMessage = '';
    this.apiService.createList(this.createList)
      .subscribe(success => {
        if (success) {
          this.taskList = this.apiService.taskList;
          this.addListToView();
        }
      }, error => this.errorMessage = 'Failed create list');
  }

  private loadLists() {
    this.apiService.loadLists().subscribe(success => {
      if (success) {
        this.taskLists = this.apiService.taskLists;
        if (this.taskLists.length > 0) {
          this.loadTasks({}, this.taskLists[0]);
        }
      }
    }, error => this.errorMessage = 'Failed load lists');
  }

  private addListToView() {
    this.taskLists.unshift(this.taskList);
    this.activeListId = this.taskList.id;
    this.tasks = [];
  }

}
