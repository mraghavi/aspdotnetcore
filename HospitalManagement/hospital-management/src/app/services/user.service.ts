import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5057/api';  // Replace with your backend URL

  constructor(private http: HttpClient) {}

  // Get users by role (for Admin)
  getUsersByRole(role: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/user/users?role=${role}`);
  }

  // Get services with doctors for Patient
  getServicesWithDoctors(): Observable<any> {
    return this.http.get(`${this.apiUrl}/patient/services-with-doctors`);
  }

  // Get services for Doctor portal
  getServices(): Observable<any> {
    return this.http.get(`${this.apiUrl}/doctor/services`);
  }

  // Add service (for Admin)
  addService(service: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/admin/add-service`, service);
  }

   // Approve doctor for service (for Admin)
   approveDoctorForService(serviceId: string, doctorId: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/admin/approve-service`, { serviceId, doctorId });
  }

   // Register doctor for a service
   registerDoctorForService(serviceId: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/doctor/register-service`, { serviceId });
  }

  // Remove service (for Admin)
  removeService(serviceId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/admin/remove-service/${serviceId}`);
  }
}
