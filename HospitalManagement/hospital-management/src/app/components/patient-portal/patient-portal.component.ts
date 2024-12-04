import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-patient-portal',
  imports: [CommonModule],
  templateUrl: './patient-portal.component.html',
  styleUrl: './patient-portal.component.css'
})
export class PatientPortalComponent implements OnInit {
  servicesWithDoctors: any[] = [];

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.getServicesWithDoctors().subscribe((data: any[]) => {
      this.servicesWithDoctors = data.filter(service => service.approved);
    });
  }
}