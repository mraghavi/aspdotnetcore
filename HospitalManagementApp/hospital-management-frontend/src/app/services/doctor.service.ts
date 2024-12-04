import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Service {
  id: string;
  name: string;
  description: string;
  isActive: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  private apiUrl = 'http://localhost:5006/api/doctor';  // Base URL is defined in the service

  constructor(private http: HttpClient) {}

  
  getActiveServices(doctorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/services/${doctorId}`);
  }
  registerForService(registration: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register-service`, registration);
  }

  // Get doctor registrations and their statuses
  getDoctorRegistrations(doctorId: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/doctor-registrations/${doctorId}`);
  }
}
