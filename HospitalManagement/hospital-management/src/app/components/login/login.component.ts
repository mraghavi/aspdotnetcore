import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router, RouterEvent, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule,RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private userService: UserService, private router: Router) {}

  onSubmit() {
    this.userService.login(this.username, this.password).subscribe({
      next: (response) => {
        // Store the user data in local storage
        const user = response;
        localStorage.setItem('user', JSON.stringify(user));

        // Redirect to respective portals based on the role
        if (user.role === 'Admin') {
          this.router.navigate(['/admin']);
        } else if (user.role === 'Doctor') {
          this.router.navigate(['/doctor']);
        } else if (user.role === 'Patient') {
          this.router.navigate(['/patient']);
        }
      },
      error: (error) => {
        alert('Invalid credentials');
      }
    });
  }
}