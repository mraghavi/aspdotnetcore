import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = 'http://localhost:7041/api/todo'; // Update the API URL if needed

  constructor(private http: HttpClient) {}

  // Get all Todos
  getTodos(): Observable<Todo[]> {
    return this.http.get<Todo[]>(this.apiUrl);
  }

  // Add a new Todo
  createTodo(newTodo: Todo): Observable<Todo> {
    return this.http.post<Todo>(this.apiUrl, newTodo);
  }

  // Update a Todo
  updateTodo(id: number, updatedTodo: Todo): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, updatedTodo);
  }

  // Delete a Todo
  deleteTodo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

export interface Todo {
  id: number;
  title: string;
  isCompleted: boolean;
}
