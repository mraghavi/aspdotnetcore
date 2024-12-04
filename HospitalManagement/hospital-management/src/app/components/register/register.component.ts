import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { tap } from 'rxjs/operators';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  imports: [FormsModule,CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  user = {
    username: '',
    password: '',
    role: 'Patient'  // Default role
  };

  constructor(private authService: AuthService, private router: Router) {}

  register() {
    this.authService.register(this.user)
      .pipe(
        tap(response => {
          alert('Registration successful!');
          this.router.navigate(['/login']);
        }),
        catchError(error => {
          alert('Registration failed.');
          return of(null); // Handle the error and return an observable
        })
      )
      .subscribe();
  }
} 