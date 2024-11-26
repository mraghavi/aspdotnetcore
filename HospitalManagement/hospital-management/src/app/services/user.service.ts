import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5057/api/User';  // Update with your backend URL

  constructor(private http: HttpClient) {}

  // Register method (no change needed)
  register(user: { role: string, username: string, password: string }): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  // Login method (no change needed)
  login(username: string, password: string): Observable<any> {
    const loginData = { username, password }; 
    return this.http.post(`${this.apiUrl}/login`, loginData);
  }

  // Get users by role (Doctor or Patient)
  getUsersByRole(role: string): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiUrl}/users?role=${role}`);
  }
}