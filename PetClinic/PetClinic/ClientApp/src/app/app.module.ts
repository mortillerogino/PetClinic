import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
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
    LoginComponent
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
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'patient', component: PatientComponent },
      { path: 'patient/details', component: DetailsComponent },
      { path: 'patient/add', component: AddComponent },
      { path: 'patient/details/edit', component: EditComponent },
      { path: 'veterinarian', component: VeterinarianComponent },
      { path: 'login', component: LoginComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
