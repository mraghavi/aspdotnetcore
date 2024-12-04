import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  imports: [FormsModule,CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  user = { name: '', email: '', password: '', role: 'Patient' }; // Default role
  errorMessage = '';

  constructor(private userService: UserService, private router: Router) {}

  validateForm(): boolean {
    if (!this.user.name || !this.user.email || !this.user.password) {
      this.errorMessage = 'All fields are required.';
      return false;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(this.user.email)) {
      this.errorMessage = 'Invalid email format.';
      return false;
    }

    if (this.user.password.length < 6) {
      this.errorMessage = 'Password must be at least 6 characters long.';
      return false;
    }

    this.errorMessage = '';
    return true;
  }

  register() {
    if (!this.validateForm()) return;

    this.userService.register(this.user).subscribe({
      next: () => {
        alert('Registration successful! Please log in.');
        this.router.navigate(['/login']); // Redirect to login portal
      },
      error: (err) => alert(err.error || 'Registration failed!'),
    });
  }
}