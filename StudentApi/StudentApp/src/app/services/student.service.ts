import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

interface Student {
  id: number;
  name: string;
  age: number;
  course: string;
}

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private apiUrl = 'http://localhost:5011/api/Students';

  constructor(private http: HttpClient) { }

  getAllStudents(): Observable<Student[]> {
    console.log('Fetching all students...');
    return this.http.get<Student[]>(this.apiUrl).pipe(
      catchError((error) => {
        console.error('Error fetching students:', error);
        throw error;
      })
    );
  }

  getStudentById(id: number): Observable<Student> {
    console.log(`Fetching student with id ${id}`);
    return this.http.get<Student>(`${this.apiUrl}/${id}`).pipe(
      catchError((error) => {
        console.error(`Error fetching student with id ${id}:`, error);
        throw error;
      })
    );
  }

  addStudent(student: Student): Observable<Student> {
    console.log('Adding student:', student);
    return this.http.post<Student>(this.apiUrl, student).pipe(
      catchError((error) => {
        console.error('Error adding student:', error);
        throw error;
      })
    );
  }

  updateStudent(id: number, student: Student): Observable<void> {
    console.log(`Updating student with id ${id}:`, student);
    return this.http.put<void>(`${this.apiUrl}/${id}`, student).pipe(
      catchError((error) => {
        console.error(`Error updating student with id ${id}:`, error);
        throw error;
      })
    );
  }

  deleteStudent(id: number): Observable<void> {
    console.log(`Deleting student with id ${id}`);
    return this.http.delete<void>(`${this.apiUrl}/${id}`).pipe(
      catchError((error) => {
        console.error(`Error deleting student with id ${id}:`, error);
        throw error;
      })
    );
  }
}