import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-admin-portal',
  imports: [FormsModule,CommonModule],
  templateUrl: './admin-portal.component.html',
  styleUrl: './admin-portal.component.css'
})
export class AdminPortalComponent implements OnInit {
  users: any[] = [];
  patients: any[] = [];
  services: any[] = [];
  newService = { name: '' };

  constructor(
    private authService: AuthService,  // Inject AuthService
    private userService: UserService
  ) {}

  ngOnInit() {
    // Fetch doctors using AuthService
    this.authService.getUsersByRole('Doctor').subscribe((doctors: any[]) => {
      this.users = doctors;
    });

    // Fetch patients using AuthService
    this.authService.getUsersByRole('Patient').subscribe((patients: any[]) => {
      this.patients = patients;
    });

    // Fetch services to manage using UserService
    this.userService.getServices().subscribe((services: any[]) => {
      this.services = services;
    });
  }

  addService() {
    this.userService.addService(this.newService).subscribe(() => {
      alert('Service added successfully');
      this.newService.name = '';
    });
  }

  removeService(serviceId: string) {
    this.userService.removeService(serviceId).subscribe(() => {
      alert('Service removed successfully');
      this.services = this.services.filter(service => service.id !== serviceId);
    });
  }

  approveService(serviceId: string, doctorId: string) {
    this.userService.approveDoctorForService(serviceId, doctorId).subscribe(() => {
      alert('Service approved for the doctor');
      // You may want to refetch services here after approval
      this.ngOnInit();
    });
  }
}