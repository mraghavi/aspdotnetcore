import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  credentials = { email: '', password: '' };
  errorMessage = '';

  constructor(private userService: UserService, private router: Router) {}

  validateForm(): boolean {
    if (!this.credentials.email || !this.credentials.password) {
      this.errorMessage = 'Both email and password are required.';
      return false;
    }

    this.errorMessage = '';
    return true;
  }

  login() {
    if (!this.validateForm()) return;

    this.userService.login(this.credentials).subscribe({
      next: (response) => {
        alert('Login successful!');
        this.redirectToPortal(response.role);
      },
      error: (err) => (this.errorMessage = err.error || 'Invalid email or password!'),
    });
  }

  redirectToPortal(role: string) {
    if (role === 'Patient') this.router.navigate(['/patient']);
    else if (role === 'Doctor') this.router.navigate(['/doctor']);
    else if (role === 'Admin') this.router.navigate(['/admin']);
  }
}