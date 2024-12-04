import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-doctor-portal',
  imports: [CommonModule],
  templateUrl: './doctor-portal.component.html',
  styleUrl: './doctor-portal.component.css'
})
export class DoctorPortalComponent implements OnInit {
  services: any[] = [];
  pendingServices: any[] = [];
  approvedServices: any[] = [];

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.getServices().subscribe((services: any[]) => {
      this.services = services.filter(service => !service.approved);
      this.pendingServices = services.filter(service => !service.approved);
      this.approvedServices = services.filter(service => service.approved);
    });
  }

  registerForService(serviceId: string) {
    this.userService.registerDoctorForService(serviceId).subscribe(() => {
      alert(`You have registered for service ID: ${serviceId}`);
      // You might want to refresh the services list here
    });
  }
}