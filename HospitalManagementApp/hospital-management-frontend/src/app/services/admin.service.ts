import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';



export interface Service {
  id: string;
  name: string | null; 
  description: string | null;  
  isActive: boolean;
}
export interface User {
  id: string;
  name: string;  // Updated to 'name' to match backend model
  email: string;
  role: string;
}



@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private apiUrl = 'http://localhost:5006/api/admin';  // Change this to match your backend URL

  constructor(private http: HttpClient) { }
   // Get all users
   getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/users`);
  }

  // Get all services
  getServices(): Observable<Service[]> {
    return this.http.get<Service[]>(`${this.apiUrl}/services`);
  }

  // Create a new service
  createService(service: Service): Observable<any> {
    return this.http.post(`${this.apiUrl}/services`, service);
  }

  // Edit an existing service
  editService(id: string, updatedService: Service): Observable<any> {
    return this.http.put(`${this.apiUrl}/services/${id}`, updatedService);
  }

  // Delete a service (mark as inactive)
  deleteService(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/services/${id}`);
  }
}
