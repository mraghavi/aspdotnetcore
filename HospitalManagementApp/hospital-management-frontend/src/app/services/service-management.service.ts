import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceManagementService {
  private adminApiUrl = 'http://localhost:5006/api/admin'; // Update port as needed
  private doctorApiUrl = 'http://localhost:5006/api/doctor'; // Update port as needed

  constructor(private http: HttpClient) {}

  // Admin Service Management
  getServices(): Observable<any> {
    return this.http.get(`${this.adminApiUrl}/services`);
  }

  createService(service: any): Observable<any> {
    return this.http.post(`${this.adminApiUrl}/services`, service);
  }

  editService(serviceId: string, updatedService: any): Observable<any> {
    return this.http.put(`${this.adminApiUrl}/services/${serviceId}`, updatedService);
  }

  deleteService(serviceId: string): Observable<any> {
    return this.http.delete(`${this.adminApiUrl}/services/${serviceId}`);
  }

  // Doctor Services
  getDoctorServices(doctorId: string): Observable<any> {
    return this.http.get(`${this.doctorApiUrl}/services/${doctorId}`);
  }
}
