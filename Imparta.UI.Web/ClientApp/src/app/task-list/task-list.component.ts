import { Component, Input } from '@angular/core';
import { Task } from './../types';
import { ApiService } from './../api.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html'
})

export class TaskListComponent {
  @Input() tasks: Task[];
  @Input() taskListId: string;

  private task: Task;

  public createTask = {
    description: '',
    start: new Date(),
    end: new Date(),
    taskListId: ''
  }

  errorMessage: string = '';

  constructor(private apiService: ApiService) {
  }

  public onNewTask() {
    this.errorMessage = '';
    this.setActiveListId();

    this.apiService.createTask(this.createTask)
      .subscribe(success => {
        if (success) {
          this.task = this.apiService.task;
          this.addTasktoTasks();
          this.resetFormFields();
        }
      }, err => this.errorMessage = 'Failed to add task');
  }

  public updateTask(event, task: Task) {

  }

  public startTask(event, task: Task) {
    this.apiService.startTask(task.id).subscribe(success => {
      this.task = this.apiService.task;
      this.updateTaskInView();
    }, error => this.errorMessage = 'Failed to start task');
  }

  public completeTask(event, task: Task) {
    this.apiService.completeTask(task.id).subscribe(success => {
      this.task = this.apiService.task;
      this.updateTaskInView();
    }, error => this.errorMessage = 'Failed to complete task');
  }

  public openTask(event, task: Task) {
    this.apiService.openTask(task.id).subscribe(success => {
      this.task = this.apiService.task;
      this.updateTaskInView();
    }, error => this.errorMessage = 'Failed to open task');
  }

  public removeTask(event, task: Task) {
    this.apiService.removeTask(task.id).subscribe(success => {
      this.removeTaskFromView(task);
    }, error => this.errorMessage = 'Failed to remove task');
  }

  private addTasktoTasks() {
    this.tasks.unshift(this.task);
  }

  private updateTaskInView() {
    this.tasks = this.tasks.map(t => {
      return (t.id === this.task.id) ? this.task : t;
    });
  }

  private removeTaskFromView(task: Task) {
    this.tasks = this.tasks.filter(t => t.id !== task.id);
  }

  private setActiveListId() {
    this.createTask.taskListId = this.taskListId;
  }

  private resetFormFields() {
    this.createTask = {
      description: '',
      start: new Date(),
      end: new Date(),
      taskListId: ''
    };
  }
}
