import { Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { AdminPortalComponent } from './components/admin-portal/admin-portal.component';
import { PatientPortalComponent } from './components/patient-portal/patient-portal.component';
import { DoctorPortalComponent } from './components/doctor-portal/doctor-portal.component';

export const routes: Routes = [

    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'admin', component: AdminPortalComponent },
    { path: 'doctor', component: DoctorPortalComponent },
    { path: 'patient', component: PatientPortalComponent },
    { path: '**', redirectTo: '' }
];
