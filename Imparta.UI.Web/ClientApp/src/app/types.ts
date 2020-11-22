interface Task {
  id: string;
  description: string;
  status: number;
  start: Date;
  end: Date;
  createdDate: Date;
  completed: boolean;
  inProgress: boolean;
  open: boolean;
  overdue: boolean;
  taskListId: string;
  statusName: string;
}


interface TaskList {
  id: string;
  title: string;
  ownerId: string;
  createdDate: Date;
  tasksCount: number;
}

export { Task, TaskList }
