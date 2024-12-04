import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  credentials = {
    username: '',
    password: ''
  };

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.credentials).subscribe({
      next: (response) => {
        if (response.role === 'Admin') {
          this.router.navigate(['/admin-portal']);
        } else if (response.role === 'Doctor') {
          this.router.navigate(['/doctor-portal']);
        } else if (response.role === 'Patient') {
          this.router.navigate(['/patient-portal']);
        }
      },
      error: (error) => {
        alert('Invalid credentials');
      },
      complete: () => {
        console.log('Login process completed.');
      }
    });
  }
}
