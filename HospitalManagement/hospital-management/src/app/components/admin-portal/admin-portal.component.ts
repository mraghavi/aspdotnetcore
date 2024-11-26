import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin-portal',
  imports: [FormsModule,CommonModule],
  templateUrl: './admin-portal.component.html',
  styleUrl: './admin-portal.component.css'
})
export class AdminPortalComponent implements OnInit {
  doctors: string[] = [];
  patients: string[] = [];

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
    this.getUsersByRole('Doctor');
    this.getUsersByRole('Patient');
  }

  // Fetch users by role (Doctor or Patient)
  getUsersByRole(role: string) {
    this.userService.getUsersByRole(role).subscribe({
      next: (users) => {
        if (role === 'Doctor') {
          this.doctors = users;
        } else if (role === 'Patient') {
          this.patients = users;
        }
      },
      error: (err) => {
        console.error('Error fetching users by role:', err);
      }
    });
  }
}