import { Component, OnInit } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AdminService } from '../../services/admin.service';
import { Service } from '../../services/admin.service';
import { User } from '../../services/admin.service';

@Component({
  selector: 'app-admin',
  imports: [FormsModule,CommonModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit {

  services: Service[] = [];
  users: User[] = [];
  newService: Service = { id: '', name: '', description: '', isActive: true };

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.loadServices();
    this.loadUsers(); 
  }

  loadServices(): void {
    this.adminService.getServices().subscribe((services) => {
      this.services = services;
    });
  }

  loadUsers(): void {
    this.adminService.getUsers().subscribe((users) => {
      this.users = users;
    });
  }

  createService(): void {
    this.adminService.createService(this.newService).subscribe({
      next: (response) => {
        alert('Service created successfully');
        this.loadServices();
        this.newService = { id: '', name: '', description: '', isActive: true }; // Reset form
      },
      error: (err) => {
        console.error('Error creating service', err);
        alert('Failed to create service');
      }
    });
  }

  editService(id: string): void {
    const updatedService: Service = {
      id,
      name: prompt('Enter new name:'),
      description: prompt('Enter new description:'),
      isActive: confirm('Is the service active?')
    };

    if (updatedService.name && updatedService.description) {
      this.adminService.editService(id, updatedService).subscribe({
        next: () => {
          alert('Service updated successfully');
          this.loadServices();
        },
        error: (err) => {
          console.error('Error updating service', err);
          alert('Failed to update service');
        }
      });
    }
  }

  deleteService(id: string): void {
    if (confirm('Are you sure you want to deactivate this service?')) {
      this.adminService.deleteService(id).subscribe({
        next: () => {
          alert('Service marked as inactive');
          this.loadServices();
        },
        error: (err) => {
          console.error('Error deactivating service', err);
          alert('Failed to deactivate service');
        }
      });
    }
  }
}