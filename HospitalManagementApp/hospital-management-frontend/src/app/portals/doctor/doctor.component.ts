import { Component, OnInit } from '@angular/core';
import { ServiceManagementService } from '../../services/service-management.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { AdminService } from '../../services/admin.service';
import { DoctorService } from '../../services/doctor.service';
import { ActivatedRoute } from '@angular/router';

interface Service {
  id: string;
  name: string;
  description: string;
  isActive: boolean;
}

@Component({
  selector: 'app-doctor',
  imports: [CommonModule, FormsModule],
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {
  
  doctorId!: string;  // Use definite assignment assertion
  services: any[] = [];
  selectedServiceId: string = '';

  constructor(
    private doctorService: DoctorService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    // Retrieve doctorId from the route
    this.doctorId = this.route.snapshot.paramMap.get('doctorId')!;
    this.loadActiveServices();
  }

  loadActiveServices(): void {
    this.doctorService.getActiveServices(this.doctorId).subscribe(
      (response) => {
        this.services = response;
      },
      (error) => {
        console.error('Error fetching services', error);
      }
    );
  }

  registerForService(): void {
    const registration = {
      doctorId: this.doctorId,
      serviceId: this.selectedServiceId
    };

    this.doctorService.registerForService(registration).subscribe(
      (response) => {
        alert('Service registration submitted. Status: Pending');
      },
      (error) => {
        alert('Error registering for service');
        console.error('Error registering for service', error);
      }
    );
  }
}
