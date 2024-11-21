import { Component, EventEmitter, Output } from '@angular/core';
import { TodoService, Todo } from '../../services/todo.service';

@Component({
  selector: 'app-todo-form',
  templateUrl: './todo-form.component.html',
  styleUrls: ['./todo-form.component.css'],
})
export class TodoFormComponent {
  @Output() todoCreated = new EventEmitter<Todo>();
  title = '';

  constructor(private todoService: TodoService) {}

  createTodo(): void {
    const newTodo: Partial<Todo> = { title: this.title, isCompleted: false };
    this.todoService.createTodo(newTodo as Todo).subscribe((createdTodo) => {
      this.todoCreated.emit(createdTodo);
      this.title = '';
    });
  }
}
