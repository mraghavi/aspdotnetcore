import { Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AdminPortalComponent } from './components/admin-portal/admin-portal.component';
import { PatientPortalComponent } from './components/patient-portal/patient-portal.component';
import { DoctorPortalComponent } from './components/doctor-portal/doctor-portal.component';

export const routes: Routes = [
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'admin-portal', component: AdminPortalComponent }, // Updated to 'admin-portal'
    { path: 'doctor-portal', component: DoctorPortalComponent }, // Updated to 'doctor-portal'
    { path: 'patient-portal', component: PatientPortalComponent }, // Updated to 'patient-portal'
    
    // Redirect unknown paths to the login page
    { path: '', redirectTo: '/login', pathMatch: 'full' }, 
  
    // Wildcard route for undefined paths
    { path: '**', redirectTo: '/login' }
  ];
