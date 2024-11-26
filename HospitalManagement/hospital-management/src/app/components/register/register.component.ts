import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [FormsModule,RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  newUser = {
    role: '',
    username: '',
    password: ''
  };

  constructor(private userService: UserService, private router: Router) {}

  onSubmit() {
    this.userService.register(this.newUser).subscribe({
      next: (response) => {
        alert('User registered successfully');
        this.router.navigate(['/login']);
      },
      error: (error) => {
        alert('Error registering user: ' + error.error);
      }
    });
  }
}
