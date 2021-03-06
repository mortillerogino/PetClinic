import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PatientComponent } from './patient/patient.component';
import { DetailsComponent } from './patient/details/details.component';
import { AddComponent } from './patient/add/add.component';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { EditComponent } from './patient/details/edit/edit.component';
import { VeterinarianComponent } from './veterinarian/veterinarian.component';
import { LoginComponent } from './user/login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { PatientService } from './shared/patient.service';
import { AuthInterceptor } from './auth/AuthInterceptor';
import { UserService } from './shared/user.service';
import { VeterinarianService } from './shared/veterinarian.service';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { DiagnosisComponent } from './diagnosis/diagnosis.component';
import { DiagnosisListComponent } from './diagnosis/diagnosis-list/diagnosis-list.component';
import { DiagnosisFormComponent } from './diagnosis/diagnosis-form/diagnosis-form.component';
import { DiagnosisService } from './shared/diagnosis.service';
import { ExpiredComponent } from './expired/expired.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PatientComponent,
    DetailsComponent,
    AddComponent,
    EditComponent,
    VeterinarianComponent,
    LoginComponent,
    ForbiddenComponent,
    UnauthorizedComponent,
    NotfoundComponent,
    DiagnosisComponent,
    DiagnosisListComponent,
    DiagnosisFormComponent,
    ExpiredComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'patient', component: PatientComponent, canActivate: [AuthGuard] },
      { path: 'patient/details', component: DetailsComponent, canActivate: [AuthGuard] },
      { path: 'patient/add', component: AddComponent, canActivate: [AuthGuard] },
      { path: 'patient/details/edit', component: EditComponent, canActivate: [AuthGuard] },
      { path: 'veterinarian', component: VeterinarianComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      {
        path: 'diagnosis/:id/:name', component: DiagnosisComponent, canActivate: [AuthGuard], data: { permittedRoles: ['Veterinarian'] },
        children: [
          { path: 'list', component: DiagnosisListComponent },
          { path: 'form', component: DiagnosisFormComponent }
        ]
      },
      { path: 'forbidden', component: ForbiddenComponent },
      { path: 'expired', component: ExpiredComponent },
      { path: 'unauthorized', component: UnauthorizedComponent },
      { path: '**', component: NotfoundComponent },
      
    ]),
  ],
  providers: [PatientService,
    UserService,
    VeterinarianService,
    DiagnosisService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
