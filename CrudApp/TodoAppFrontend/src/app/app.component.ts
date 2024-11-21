import { Component } from '@angular/core';
import { TodoService, Todo } from './services/todo.service';
import { TodoFormComponent } from './components/todo-form/todo-form.component';
import { TodoListComponent } from './components/todo-list/todo-list.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  imports: [TodoFormComponent,TodoListComponent,FormsModule,CommonModule],
  styleUrls: ['./app.component.css'],  // Make sure the file is in the correct folder
})
export class AppComponent {
  title = 'TodoAppFrontend';

  constructor() {}

  
}

