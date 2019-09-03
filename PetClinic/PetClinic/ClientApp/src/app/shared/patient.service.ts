import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from './models/patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPatients() {
    
    return this.http.get<Patient[]>(this.baseUrl + 'api/Patient');
  }
}
