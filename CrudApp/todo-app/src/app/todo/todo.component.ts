import { Component,OnInit } from '@angular/core';
import { TodoService, Todo } from '../todo.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-todo',
  imports: [FormsModule,CommonModule],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.css'
})
export class TodoComponent implements OnInit {
  todos: Todo[] = [];
  newTodo: Todo = { id: 0, title: '', isCompleted: false };
  isEditing: boolean = false; // Flag to track if editing
  editingTodo: Todo = { id: 0, title: '', isCompleted: false }; // Initialize editingTodo to avoid null

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.loadTodos();
  }

  // Load all Todos from the service
  loadTodos(): void {
    this.todoService.getTodos().subscribe((data) => {
      this.todos = data;
    });
  }

  // Create a new Todo
  addTodo(): void {
    if (this.newTodo.title.trim()) {
      this.todoService.createTodo(this.newTodo).subscribe((todo) => {
        this.todos.push(todo);
        this.newTodo = { id: 0, title: '', isCompleted: false }; // Reset the input
      });
    }
  }

  // Update a Todo
  toggleComplete(todo: Todo): void {
    todo.isCompleted = !todo.isCompleted;
    this.todoService.updateTodo(todo.id, todo).subscribe();
  }

  // Delete a Todo
  deleteTodo(id: number): void {
    this.todoService.deleteTodo(id).subscribe(() => {
      this.todos = this.todos.filter(todo => todo.id !== id);
    });
  }

  // Start editing a Todo
  editTodo(todo: Todo): void {
    this.isEditing = true;
    this.editingTodo = { ...todo }; // Create a copy of the Todo to edit
  }

  // Save the edited Todo
  saveEdit(): void {
    if (this.editingTodo) {
      this.todoService.updateTodo(this.editingTodo.id, this.editingTodo).subscribe(() => {
        const index = this.todos.findIndex(t => t.id === this.editingTodo!.id);
        if (index !== -1) {
          this.todos[index] = this.editingTodo!;
        }
        this.cancelEdit();
      });
    }
  }

  // Cancel editing and reset the form
  cancelEdit(): void {
    this.isEditing = false;
    this.editingTodo = { id: 0, title: '', isCompleted: false }; // Reset to initial empty state
  }
}