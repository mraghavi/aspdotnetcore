import { Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { PatientComponent } from './portals/patient/patient.component';
import { DoctorComponent } from './portals/doctor/doctor.component';
import { AdminComponent } from './portals/admin/admin.component';


export const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'patient', component: PatientComponent },
  { path: 'doctor', component: DoctorComponent },
  { path: 'admin', component: AdminComponent },
];
