import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';

export interface Todo {
  id: number;
  title: string;
  isCompleted: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private apiUrl = 'http://localhost:7041/api/todo';

  constructor(private http: HttpClient) {}

  getTodos(): Observable<Todo[]> {
    return this.http.get<Todo[]>(this.apiUrl).pipe(
      catchError((error) => {
        console.error('Error fetching todos:', error);
        throw error;
      })
    );
  }

  createTodo(todo: Todo): Observable<Todo> {
    return this.http.post<Todo>(this.apiUrl, todo).pipe(
      catchError((error) => {
        console.error('Error creating todo:', error);
        throw error;
      })
    );
  }

  updateTodo(id: number, todo: Todo): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, todo).pipe(
      catchError((error) => {
        console.error('Error updating todo:', error);
        throw error;
      })
    );
  }

  deleteTodo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`).pipe(
      catchError((error) => {
        console.error('Error deleting todo:', error);
        throw error;
      })
    );
  }
}
